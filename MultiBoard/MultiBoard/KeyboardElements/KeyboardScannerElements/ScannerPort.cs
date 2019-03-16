using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultiBoard.Properties;

namespace MultiBoard.KeyboardElements.KeyboardScannerElements
{
    class ScannerPort
    {
        private string _staticId = Resources.KeyboardScanner__staticId;

        SerialPort _serialPort = new SerialPort();

        public event EventHandler BoardFound;

        public string comPort;
        private int _baudRate;
        public string uuid = "NONE";

        public ScannerPort()
        {
            _serialPort.DataReceived += SerialPortOnDataReceived;
        }

        public void setup(string port, int rate)
        {
            comPort = port;
            _baudRate = rate;

            _serialPort.BaudRate = _baudRate;
            _serialPort.PortName = comPort;
        }

        public void start()
        {
            try
            {
                _serialPort.Open();
                Thread.Sleep(2000);
                _serialPort.Write("?");
            }
            catch (UnauthorizedAccessException)
            {

            }
        }

        public void Close()
        {
            _serialPort.Close();
        }

        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            CheckReceivedData();
        }

        private void CheckReceivedData()
        {
            string input = _serialPort.ReadExisting();
            Console.WriteLine("received: " + input);

            if (input.Replace("ID:", String.Empty).Split('&').Length == 3)
            {
                if (input.Split('&')[1] == _staticId)
                {
                    //MultiBoard valid
                    uuid = input.Split('&')[2].Replace("\r\n", string.Empty);

                    if (BoardFound != null)
                    {
                        BoardFound(this, EventArgs.Empty);
                    }
                }
                
            }
            else
            {
                _serialPort.WriteLine("?");
            }
            
        }
    }
}
