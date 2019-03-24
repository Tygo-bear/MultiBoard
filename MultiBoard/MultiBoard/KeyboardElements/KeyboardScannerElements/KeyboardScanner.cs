using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using MultiBoard.Properties;

namespace MultiBoard.KeyboardElements.KeyboardScannerElements
{
    class KeyboardScanner
    {
        public List<string> Ports = new List<string>();
        public List<string> Uuid = new List<string>();

        private List<ScannerPort> _scanPorts = new List<ScannerPort>();


        /// <summary>
        /// Generate the list of available keyboards
        /// </summary>
        /// <param name="bRate">
        /// baud rate of com port (115200 default)
        /// </param>
        public void loadList(int bRate)
        {
            //Clear lists
            Ports.Clear();
            Uuid.Clear();
            _scanPorts.Clear();

            //Make list of all the com ports
            List<string> availablePorts = new List<string>();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                availablePorts.Add(s);
            }

            //open connection foreach com port
            foreach(string s in availablePorts)
            {
                ScannerPort sp = new ScannerPort();
                sp.setup(s, bRate);
                Thread t = new Thread(() => sp.start());
                t.Start();

                _scanPorts.Add(sp);
            }

            //wait 1s-10s
            System.Threading.Thread.Sleep(Properties.Settings.Default.TimeOutDelay);

            //collect results
            foreach (ScannerPort sp in _scanPorts)
            {
                Uuid.Add(sp.Uuid);
                Ports.Add(sp.ComPort);
                sp.close();
            }

            return;
        }

    }
}
