using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoardPerformMode
{
    class Keyboard
    {
        private SerialPort _comPort;

        private List<string> _keyTagList = new List<string>();
        private List<string> _keyEventList = new List<string>();
        private List<string> _executeList = new List<string>();

        public Keyboard(string fileLocation)
        {
            LoadKeys(fileLocation);
        }

        private void LoadKeys(string fileLoc)
        {
            _keyTagList.Clear();
            _executeList.Clear();

            if (!File.Exists(fileLoc))
            {
                File.Create(fileLoc).Close();
            }

            //read keys
            //============================
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(fileLoc);

            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] splits = line.Split('|');

                    _keyTagList.Add(splits[2]);
                    _keyEventList.Add(splits[1]);
                    _executeList.Add(splits[4]);
                }
            }

            file.Close();
        }

        public void setup(string com, int bRate)
        {
            _comPort = new SerialPort(com, bRate);
            _comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        public void start()
        {
            _comPort.Open();
        }

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;

            string s = _comPort.ReadExisting();
            //Console.WriteLine("Data: " + s);

            if (s.Split('<')[0] != s)
            {
                normalKey(s);
            }
            else if (s.Split('_')[0] != s)
            {
                altKey(s);
            }
            else
            {
                //altInput(s);
            }
        }

        private void normalKey(string input)
        {
            if (input.Split(new string[] { "DN" }, StringSplitOptions.None)[0] != input)
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
            if (input.Split('_')[0] == "0")
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

        private void onKeyDown(string tag)
        {
            int count = 0;
            foreach (string s in _keyEventList)
            {
                if (s == "1")
                {
                    if (_keyTagList[count] == tag)
                    {
                        System.Diagnostics.Process.Start(_executeList[count]);
                    }

                }
                count++;
            }
        }

        private void onKeyUp(string tag)
        {
            foreach (string s in _keyEventList)
            {
                int count = 0;
                if (s == "2")
                {
                    foreach (string t in _keyTagList)
                    {
                        if (t == tag)
                        {
                            System.Diagnostics.Process.Start(_executeList[count]);
                        }
                        count++;
                    }
                }

            }
        }
    }
}
