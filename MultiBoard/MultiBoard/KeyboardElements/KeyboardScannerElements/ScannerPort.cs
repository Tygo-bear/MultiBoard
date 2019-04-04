using System;
using System.IO.Ports;
using System.Threading;
using MultiBoard.Properties;

namespace MultiBoard.KeyboardElements.KeyboardScannerElements
{
    class ScannerPort 
    {
        private string _staticId = Resources.KeyboardScanner__staticId;
        private SerialPort _serialPort = new SerialPort();

        public event EventHandler BoardFound;

        public string ComPort;
        private int _baudRate;
        public string Uuid = "NONE";

        public ScannerPort()
        {
            _serialPort.DataReceived += serialPortOnDataReceived;
        }

        /// <summary>
        /// Setup the Scanner port class
        /// </summary>
        /// <param name="port">
        /// Com port to connect with
        /// </param>
        /// <param name="rate">
        /// baud rate of the com port
        /// </param>
        public void setup(string port, int rate)
        {
            ComPort = port;
            _baudRate = rate;

            _serialPort.BaudRate = _baudRate;
            _serialPort.PortName = ComPort;
        }

        /// <summary>
        /// Start connection with com port
        /// </summary>
        public void start()
        {
            try
            {
                _serialPort.Open();
                Thread.Sleep(2000);
                _serialPort.Write("?");
            }
            catch (Exception)
            {
                
            }
        }

        /// <summary>
        /// Release com port
        /// </summary>
        public void close()
        {

            _serialPort.Close();

        }

        /// <summary>
        /// Data receive of serialPort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            checkReceivedData();
        }

        /// <summary>
        /// Processes received data
        /// Validate static id and collect dynamic id
        /// </summary>
        private void checkReceivedData()
        {
            string input = _serialPort.ReadExisting();
            Console.WriteLine("received: " + input);

            if (input.Replace("ID:", String.Empty).Split('&').Length == 3)
            {
                if (input.Split('&')[1] == _staticId)
                {
                    //MultiBoard valid
                    Uuid = input.Split('&')[2].Replace("\r\n", string.Empty);

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
