using System;
using System.Collections.Generic;
using System.IO.Ports;
using MultiBoard.Properties;

namespace MultiBoard.KeyboardElements
{
    class KeyboardScanner
    {
        public List<string> Ports = new List<string>();
        public List<string> Uuid = new List<string>();

        private List<SerialPort> openSerials = new List<SerialPort>();
        private string _staticId = Resources.KeyboardScanner__staticId;

        public bool loadList(int bRate)
        {
            Ports.Clear();
            Uuid.Clear();
            openSerials.Clear();

            List<string> avaiblePorts = new List<string>();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                avaiblePorts.Add(s);
            }

            foreach(string s in avaiblePorts)
            {
                try
                {
                    SerialPort comPort = new SerialPort(s, bRate);
                    Ports.Add(s);
                    comPort.Open();
                    System.Threading.Thread.Sleep(500);
                    comPort.Write("?");
                    Console.WriteLine("send ?");

                    openSerials.Add(comPort);
                }
                catch(UnauthorizedAccessException unauthorizedAccessException)
                {

                }
            }

            System.Threading.Thread.Sleep(2000);

            foreach(SerialPort s in openSerials)
            {
                Console.WriteLine("   new board\n-------------");
                Console.WriteLine(s.PortName);
                int count = 0;
                string input = s.ReadExisting();
                Console.WriteLine("recevied: " + input);
                while (input == "" && count < 5)
                {
                    s.Write("?");
                    System.Threading.Thread.Sleep(2000);
                    input = s.ReadExisting();
                    s.Close();
                    s.Open();
                    Console.WriteLine("recevied: " + input);
                    count++;
                }
                

                if (input.Replace("ID:", String.Empty).Split('&').Length == 3)
                {
                    if (input.Split('&')[1] == _staticId)
                    {
                        //MultiBoard valid
                        Uuid.Add(input.Split('&')[2].Replace("\r\n", string.Empty));
                    }
                    else
                    {
                        Uuid.Add("NONE");
                    }
                }
                else
                {
                    Uuid.Add("NONE");
                }

                s.Close();
            }
            System.Threading.Thread.Sleep(1000);

            return true;
        }

    }
}
