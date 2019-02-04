using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiBoard
{
    class KeyboardScanner
    {
        public List<string> ports = new List<string>();
        public List<string> uuid = new List<string>();

        private List<SerialPort> openSerials = new List<SerialPort>();
        private string staticID = "86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1";

        public bool loadList(int BRate)
        {
            ports.Clear();
            uuid.Clear();
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
                    SerialPort comPort = new SerialPort(s, BRate);
                    ports.Add(s);
                    comPort.Open();
                    comPort.Write("?");

                    openSerials.Add(comPort);
                }
                catch(UnauthorizedAccessException unauthorizedAccessException)
                {

                }
            }

            System.Threading.Thread.Sleep(1000);

            foreach(SerialPort s in openSerials)
            {
                System.Threading.Thread.Sleep(1000);

                int count = 0;
                string input = s.ReadExisting();
                while (input == "" && count < 10)
                {
                    input = s.ReadExisting();
                    count++;
                }
                

                if (input.Split('&').Length == 3)
                {
                    if (input.Split('&')[1] == staticID)
                    {
                        //MultiBoard valid
                        uuid.Add(input.Split('&')[2].Replace("\r\n", string.Empty));
                        Console.Write("Found: " + input.Split('&')[2]);
                    }
                    else
                    {
                        uuid.Add("NONE");
                    }
                }
                else
                {
                    uuid.Add("NONE");
                }

                s.Close();
            }
            System.Threading.Thread.Sleep(1000);

            return true;
        }

    }
}
