using System;
using System.IO.Ports;

namespace MultiBoard
{
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

    class Connector
    {
        private SerialPort _comPort;

        private bool _connectioValid = false;
        private readonly string _staticId = "86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1";
        public string DynamicId; 

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

        public void openPort()
        {
            _comPort.Open();
            _comPort.Write("?");
        }

        public void closePort()
        {
            _comPort.Close();
        }

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
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
            

            string s = _comPort.ReadExisting();
            //Console.WriteLine("Data: " + s);

            if (s.Split('<')[0] != s)
            {
                normalKey(s);
            }
            else if(s.Split('_')[0] != s)
            {
                altKey(s);
            }
            else
            {
                altInput(s);
            }
        }

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

        private string extractKey(string input)
        {
            input = input.Split('>')[1];
            input = input.Split('<')[0];

            return ">" + input + "<";
        }

        private void altKey(string input)
        {
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

        private void altInput(string input)
        {
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

        //connection event handlers
        public event EventHandler<UuidEventArgs> Connected;
        public event EventHandler<UuidEventArgs> ConnectionLost;
        public event EventHandler<ErrorEventArgs> Error;
         
        //key event hanlders
        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<KeyEventArgs> KeyUp;
        public event EventHandler<KeyEventArgs> KeyPressed;

        //events
        //connection events
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

    
}
