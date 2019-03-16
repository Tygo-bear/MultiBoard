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

        private List<ScannerPort> _ScanPorts = new List<ScannerPort>();

        public bool loadList(int bRate)
        {
            Ports.Clear();
            Uuid.Clear();
            _ScanPorts.Clear();

            List<string> avaiblePorts = new List<string>();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                avaiblePorts.Add(s);
            }

            foreach(string s in avaiblePorts)
            {
                ScannerPort sp = new ScannerPort();
                sp.setup(s, bRate);
                Thread t = new Thread(() => sp.start());
                t.Start();

                _ScanPorts.Add(sp);
            }

            System.Threading.Thread.Sleep(6000);

            foreach (ScannerPort sp in _ScanPorts)
            {
                Uuid.Add(sp.uuid);
                Ports.Add(sp.comPort);
                sp.Close();
            }

            return true;
        }

    }
}
