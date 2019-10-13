using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using MultiBoard.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;

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
            Debug.WriteLine("--comports--");
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                availablePorts.Add(s);
                Debug.WriteLine("   comports: " + s);
            }

            //open connection foreach com port
            foreach (string s in availablePorts)
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
    }

}
