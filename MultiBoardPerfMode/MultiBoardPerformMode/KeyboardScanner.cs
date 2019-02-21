using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoardPerformMode
{
    class KeyboardScanner
    {
        public List<string> Ports = new List<string>();
        public List<string> Uuid = new List<string>();

        private List<SerialPort> openSerials = new List<SerialPort>();
        private string _staticId = "86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1";

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

            foreach (string s in avaiblePorts)
            {
                try
                {
                    SerialPort comPort = new SerialPort(s, bRate);
                    Ports.Add(s);
                    comPort.Open();
                    comPort.Write("?");

                    openSerials.Add(comPort);
                }
                catch (UnauthorizedAccessException unauthorizedAccessException)
                {

                }
            }

            System.Threading.Thread.Sleep(1000);

            foreach (SerialPort s in openSerials)
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
