using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MultiBoard
{
    public class uuidEventArgs : EventArgs
    {
        public string uuid { get; set; }
    }

    public class ErrorEventArgs : EventArgs
    {
        public string error { get; set; }
    }

    public class KeyEventArgs : EventArgs
    {
        public string key { get; set; }
    }

    class connector
    {
        private SerialPort comPort;

        private bool connectioValid = false;
        private string staticID = "86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1";
        public string dynamicID; 

        KeySpace KSpace = new KeySpace();

        public void setup(string com, int BRate)
        {
            comPort = new SerialPort(com, BRate);
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        private void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Console.WriteLine("error: " + e);
        }

        public void openPort()
        {
            comPort.Open();
            comPort.Write("?");
        }

        public void closePort()
        {
            comPort.Close();
            KSpace.emtySpace();
        }

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = comPort.ReadExisting();
            Console.WriteLine("Data: " + s);

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
                OnKeyDown(input.Split('_')[1]);
            }
            else
            {
                //alt key up
                OnKeyUp(input.Split('_')[0]);
            }
        }

        private void altInput(string input)
        {
            if(input.Split(new string[] { "ID:" }, StringSplitOptions.None)[0] != input && connectioValid == false)
            {
                if(input.Split('&')[1] == staticID)
                {
                    //MultiBoard valid
                    dynamicID = input.Split('&')[2];
                    connectioValid = true;
                    Console.WriteLine("valid connection!");
                    OnConnected(dynamicID);
                }
            }
        }

        //connection event handlers
        public event EventHandler<uuidEventArgs> Connected;
        public event EventHandler<uuidEventArgs> ConnectionLost;
        public event EventHandler<ErrorEventArgs> Error;
         
        //key event hanlders
        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<KeyEventArgs> KeyUp;
        public event EventHandler<KeyEventArgs> KeyPressed;

        //events
        //connection events
        protected virtual void OnConnected(string UUID)
        {
            if(Connected != null)
            {
                Connected(this, new uuidEventArgs() { uuid = UUID });
            }
        }

        protected virtual void OnConnectionLost(string UUID)
        {
            if(ConnectionLost != null)
            {
                ConnectionLost(this, new uuidEventArgs() { uuid = UUID });
            }
        }

        protected virtual void OnError(string ERROR)
        {
            if (Error != null)
            {
                Error(this, new ErrorEventArgs() { error = ERROR });
            }
        }

        //key events
        protected virtual void OnKeyDown(string KEY)
        {
            //Console.WriteLine("KEY: " + KEY);

            if (KeyDown != null)
            {
                //KSpace.keyDown(KEY);
                KeyDown(this, new KeyEventArgs() { key = KEY });
            }
        }

        protected virtual void OnKeyUp(string KEY)
        {
            //Console.WriteLine("KEY: " + KEY);

            if (KeyUp != null)
            {
                //KSpace.keyUp(KEY);
                KeyUp(this, new KeyEventArgs() { key = KEY });
            }
        }

        protected virtual void OnKeyPressed(string KEY)
        {
            if (KeyPressed != null)
            {
                KeyPressed(this, new KeyEventArgs() { key = KEY });
            }
        }
    }

    
}
