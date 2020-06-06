using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Management;

namespace MultiBoard.KeyboardElements.KeyboardScannerElements
{
    class KeyboardScanner
    {
        public List<string> Ports = new List<string>();
        public List<string> Uuid = new List<string>();

        private List<ScannerPort> _scanPorts = new List<ScannerPort>();
        private bool _safeMode;
        public int TimeOutDelay;
        private string _staticId;

        public KeyboardScanner(int timeOutDelay, string staticId, bool safeMode = true)
        {
            TimeOutDelay = timeOutDelay;
            _staticId = staticId;
            _safeMode = safeMode;
        }


        /// <summary>
        /// Generate the list of available keyboards
        /// </summary>
        /// <param name="bRate">
        /// baud rate of com port (115200 default)
        /// </param>
        public void loadList(int bRate)
        {
            GetSerialPort();

            //Clear lists
            Ports.Clear();
            Uuid.Clear();
            _scanPorts.Clear();

            //Make list of all the com ports
            List<string> availablePorts;
            if (_safeMode)
            {
                Debug.WriteLine("COM ports scan mode 1");
                availablePorts = GetSerialPort();
            }
            else
            {
                Debug.WriteLine("COM ports scan mode 2");
                availablePorts = new List<string>();
                foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                {
                    availablePorts.Add(s);
                }
            }


            //Debug, print all found comports
            Debug.WriteLine("--comports--");
            foreach (string port in availablePorts)
            {
                Debug.WriteLine("   comports: " + port);
            }
            

            //open connection foreach com port
            foreach (string s in availablePorts)
            {
                ScannerPort sp = new ScannerPort(_staticId);
                sp.setup(s, bRate);
                Thread t = new Thread(() => sp.start());
                t.Start();

                _scanPorts.Add(sp);
            }

            //wait 1s-10s
            System.Threading.Thread.Sleep(TimeOutDelay);

            //collect results
            Debug.WriteLine("--scan results--");
            foreach (ScannerPort sp in _scanPorts)
            {
                Uuid.Add(sp.Uuid);
                Ports.Add(sp.ComPort);

                Debug.WriteLine("   {0} result: {1}", sp.ComPort, sp.Uuid);

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    sp.close();

                }).Start();

            }

            return;
        }

        /// <summary>
        /// Alternative way off searching for available comports
        /// </summary>
        /// <returns>List of all found COM ports</returns>
        private List<string> GetSerialPort()
        {
            List<string> availablePorts = new List<string>();

            try
            {
                ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
                ManagementObjectCollection Ports = processClass.GetInstances();
                foreach (ManagementObject property in Ports)
                {
                    var name = property.GetPropertyValue("Name");
                    if (name != null && name.ToString().Contains("USB") && name.ToString().Contains("COM"))
                    {
                        string s = name.ToString();
                        int start = s.IndexOf("(") + 1;
                        int end = s.IndexOf(")", start);
                        string result = s.Substring(start, end - start);
                        availablePorts.Add(result);
                    }
                }
            }
            catch (ManagementException e)
            {
                
            }

            return availablePorts;

        }
    }

}
