using System;
using System.IO.Ports;
using System.Threading;

namespace MultiBoard
{

    class Connector
    {
        //Events
        //============================

        //connection event handlers
        public event EventHandler<UuidEventArgs> Connected;
        public event EventHandler<UuidEventArgs> ConnectionLost;
        public event EventHandler<ErrorEventArgs> Error;

        //key event handlers
        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<KeyEventArgs> KeyUp;
        public event EventHandler<KeyEventArgs> KeyPressed;

        //Class
        //===============
        private SerialPort _comPort;

        //Vars
        //=================
        private int _retryMax = 0;
        private bool _connectioValid;
        private readonly string _staticId = Properties.Resources.KeyboardScanner__staticId;
        public string DynamicId; 

        /// <summary>
        /// Setup connection settings of connector class
        /// </summary>
        /// <param name="com">
        /// The com port of the keyboard
        /// </param>
        /// <param name="bRate">
        /// The baudrate of the com port
        /// </param>
        public void setup(string com, int bRate)
        {
            _comPort = new SerialPort(com, bRate);
            _comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            _comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        private void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            //Console.WriteLine("error: " + e);
        }

        /// <summary>
        /// Open the serial port with current settings
        /// </summary>
        public void openPort()
        {
            _comPort.Open();
            _comPort.Write("?");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.Sleep(Properties.Settings.Default.TimeOutDelay);
                validedConnection();

            }).Start();
        }

        /// <summary>
        /// Close the com port / release com port
        /// </summary>
        public void closePort()
        {
            _comPort.Close();
            _connectioValid = false;
        }

        private bool validedConnection()
        {
            if(_connectioValid == true)
            {
                return true;
            }

            _retryMax++;
            if (_retryMax < 5)
            {
                Properties.Settings.Default.ErrorList += ", connection fialed reconnecting:" + _retryMax +" --> " + _comPort;
                Properties.Settings.Default.Save();
                reConnect();
            }
            return false;
        }

        /// <summary>
        /// reconnect comport and valide conection
        /// </summary>
        public void reConnect()
        {
            closePort();
            openPort();
        }

        /// <summary>
        /// Read received data of the com port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Processes priority as settings define
            switch (Properties.Settings.Default.ThreadPriority)
            {
                case 1:
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle;
                    break;
                case 2:
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal;
                    break;
                case 3:
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
                    break;
                case 4:
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                    break;
                case 5:
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
                    break;
                case 6:
                    System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
                    break;
            }
            
            //Read received data
            string s = _comPort.ReadExisting();
            if(s.Contains("ID:"))
            {
                Thread.Sleep(10);
                if (_comPort.IsOpen)
                {
                    s += _comPort.ReadExisting();
                }
            }
            //Console.WriteLine("Data: " + s);

            s = s.Replace("\n", "");
            s = s.Replace("\r","");

            //Sort received data
            if (s.Split('<')[0] != s)
            {
                //normal input
                normalKey(s);
            }
            else if(s.Split('_')[0] != s)
            {
                //alternative keys
                altKey(s);
            }
            else
            {
                //alternative input
                altInput(s);
            }
        }

        /// <summary>
        /// Read normal key input
        /// </summary>
        /// <param name="input">
        /// input/received data
        /// </param>
        private void normalKey(string input)
        {
            if(input.Split(new string[] { "DN" }, StringSplitOptions.None)[0] != input)
            {
                //down key
                string key = extractKey(input);
                //Console.WriteLine("Key DN: " + key);
                onKeyDown(key);
            }
            else if (input.Split(new string[] { "UP" }, StringSplitOptions.None)[0] != input)
            {
                //up key
                string key = extractKey(input);
                //Console.WriteLine("Key UP: " + key);
                onKeyUp(key);
            }
            else
            {

            }
        }

        /// <summary>
        /// Extract key code out of normal input
        /// </summary>
        /// <param name="input">
        /// the key input
        /// </param>
        /// <returns>
        /// key code
        /// </returns>
        private string extractKey(string input)
        {
            input = input.Split('>')[1];
            input = input.Split('<')[0];

            return ">" + input + "<";
        }

        /// <summary>
        /// Read alternative key input
        /// </summary>
        /// <param name="input">
        /// The key input
        /// </param>
        private void altKey(string input)
        {
            //sort by up/down
            if(input.Split('_')[0] == "0")
            {
                //alt key down
                onKeyDown(input.Split('_')[1]);
            }
            else
            {
                //alt key up
                onKeyUp(input.Split('_')[0]);
            }
        }

        /// <summary>
        /// Read alternative input (no key input)
        /// </summary>
        /// <param name="input">
        /// The input
        /// </param>
        private void altInput(string input)
        {
            //try to read as ID
            if(input.Split(new string[] { "ID:" }, StringSplitOptions.None)[0] != input && _connectioValid == false)
            {
                if (input.Split('&').Length > 2)
                {
                    if (input.Split('&')[1] == _staticId)
                    {
                        //MultiBoard valid
                        DynamicId = input.Split('&')[2].Replace("\r\n", string.Empty);
                        _connectioValid = true;
                        //Console.WriteLine("valid connection!");
                        onConnected(DynamicId);
                    }
                }
            }
        }

        //connection events
        //====================
        protected virtual void onConnected(string uuid)
        {
            if(Connected != null)
            {
                Connected(this, new UuidEventArgs() { Uuid = uuid });
            }
        }

        protected virtual void onConnectionLost(string uuid)
        {
            if(ConnectionLost != null)
            {
                ConnectionLost(this, new UuidEventArgs() { Uuid = uuid });
            }
        }

        protected virtual void onError(string error)
        {
            if (Error != null)
            {
                Error(this, new ErrorEventArgs() { Error = error });
            }
        }

        //key events
        //====================
        protected virtual void onKeyDown(string key)
        {
            //Console.WriteLine("KEY: " + KEY);
            
            if (KeyDown != null)
            {
                KeyDown(this, new KeyEventArgs() { Key = key });
            }
        }

        protected virtual void onKeyUp(string key)
        {
            //Console.WriteLine("KEY: " + key);

            if (KeyUp != null)
            {
                KeyUp(this, new KeyEventArgs() { Key = key });
            }
        }

        protected virtual void onKeyPressed(string key)
        {
            if (KeyPressed != null)
            {
                KeyPressed(this, new KeyEventArgs() { Key = key });
            }
        }

    }

    public class UuidEventArgs : EventArgs
    {
        public string Uuid { get; set; }
    }

    public class ErrorEventArgs : EventArgs
    {
        public string Error { get; set; }
    }

    public class KeyEventArgs : EventArgs
    {
        public string Key { get; set; }
    }


}
