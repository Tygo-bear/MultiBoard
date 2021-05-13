using System;
using System.IO.Ports;
using System.Threading;

namespace MultiBoardKeyboard
{
    class ScannerPort 
    {
        private string _staticId;
        private SerialPort _serialPort = new SerialPort();

        public event EventHandler BoardFound;

        public string ComPort;
        private int _baudRate;
        public string Uuid = "NONE";

        private string input = "";

        public ScannerPort(string staticId)
        {
            _staticId = staticId;
            _serialPort.DataReceived += SerialPortOnDataReceived;
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
        public void Setup(string port, int rate)
        {
            ComPort = port;
            _baudRate = rate;

            _serialPort.BaudRate = _baudRate;
            _serialPort.PortName = ComPort;
        }

        /// <summary>
        /// Start connection with com port
        /// </summary>
        public void Start()
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
        public void Close()
        {
            try
            {
                _serialPort.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        /// <summary>
        /// Data receive of serialPort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            CheckReceivedData();
        }

        /// <summary>
        /// Processes received data
        /// Validate static id and collect dynamic id
        /// </summary>
        private void CheckReceivedData()
        {
            try
            {
                input = _serialPort.ReadExisting();
                if (input.Contains("ping"))
                    input = input.Replace("ping", "");

                input = input.Replace("\r\n", string.Empty);


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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
