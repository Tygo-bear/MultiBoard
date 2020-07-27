using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace MultiBoardKeyboard
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
        private string _staticId;
        public string DynamicId;

        public int ThreadPriority = 6;
        public int TimeoutDelay;

        public Connector(string staticId, int timeoutDelay)
        {
            _staticId = staticId;
            TimeoutDelay = timeoutDelay;
        }

        /// <summary>
        /// Setup connection settings of connector class
        /// </summary>
        /// <param name="com">
        /// The com port of the keyboard
        /// </param>
        /// <param name="bRate">
        /// The baudrate of the com port
        /// </param>
        public void Setup(string com, int bRate)
        {
            _comPort = new SerialPort(com, bRate);
            _comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            _comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        private void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Debug.WriteLine("error from {0} gave: {1}", _comPort.PortName, e.ToString());
        }

        /// <summary>
        /// Open the serial port with current settings
        /// </summary>
        public void OpenPort()
        {
            try
            {
                _comPort.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                OnError("com open failed:" + _comPort);
                return;
            }
            
            _comPort.Write("?");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.Sleep(TimeoutDelay);
                CheckValidConnection();

            }).Start();
        }

        /// <summary>
        /// Close the com port / release com port
        /// </summary>
        public void ClosePort()
        {
            if (_comPort != null)
            {
                _comPort.Close();
            }
            _connectioValid = false;
        }

        private bool CheckValidConnection()
        {
            Debug.WriteLine("try check valid connection from {0} attempt {1}", _comPort.PortName, _retryMax);
            if (_connectioValid == true)
            {
                Debug.WriteLine("valid connection on " + _comPort.PortName);
                return true;
                
            }

            _retryMax++;
            if (_retryMax < 5)
            {
                OnError("connection failed reconnecting:" + _retryMax + " --> " + _comPort);
                ReConnect();
            }
            return false;
        }

        /// <summary>
        /// reconnect comport and valide conection
        /// </summary>
        public void ReConnect()
        {
            ClosePort();
            OpenPort();
        }

        /// <summary>
        /// Read received data of the com port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Processes priority as settings define
            switch (ThreadPriority)
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
                NormalKey(s);
            }
            else if(s.Split('_')[0] != s)
            {
                //alternative keys
                AltKey(s);
            }
            else
            {
                //alternative input
                AltInput(s);
            }
        }

        /// <summary>
        /// Read normal key input
        /// </summary>
        /// <param name="input">
        /// input/received data
        /// </param>
        private void NormalKey(string input)
        {
            if(input.Split(new string[] { "DN" }, StringSplitOptions.None)[0] != input)
            {
                //down key
                string key = extractKey(input);
                //Console.WriteLine("Key DN: " + key);
                OnKeyDown(key);
            }
            else if (input.Split(new string[] { "UP" }, StringSplitOptions.None)[0] != input)
            {
                //up key
                string key = extractKey(input);
                //Console.WriteLine("Key UP: " + key);
                OnKeyUp(key);
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
        private void AltKey(string input)
        {
            //sort by up/down
            if(input.Split('_')[0] == "0")
            {
                //alt key down
                OnKeyDown(input.Split('_')[1]);
            }
            else
            {
                //alt key up
                OnKeyUp(input.Split('_')[0]);
            }
        }

        /// <summary>
        /// Read alternative input (no key input)
        /// </summary>
        /// <param name="input">
        /// The input
        /// </param>
        private void AltInput(string input)
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
                        OnConnected(DynamicId);
                    }
                }
            }
        }

        //connection events
        //====================
        protected virtual void OnConnected(string uuid)
        {
            if(Connected != null)
            {
                Connected(this, new UuidEventArgs() { Uuid = uuid });
            }
        }

        protected virtual void OnConnectionLost(string uuid)
        {
            if(ConnectionLost != null)
            {
                ConnectionLost(this, new UuidEventArgs() { Uuid = uuid });
            }
        }

        protected virtual void OnError(string error)
        {
            if (Error != null)
            {
                Error(this, new ErrorEventArgs() { Error = error });
            }
        }

        //key events
        //====================
        protected virtual void OnKeyDown(string key)
        {
            //Console.WriteLine("KEY: " + KEY);
            
            if (KeyDown != null)
            {
                KeyDown(this, new KeyEventArgs() { Key = key });
            }
        }

        protected virtual void OnKeyUp(string key)
        {
            //Console.WriteLine("KEY: " + key);

            if (KeyUp != null)
            {
                KeyUp(this, new KeyEventArgs() { Key = key });
            }
        }

        protected virtual void OnKeyPressed(string key)
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
