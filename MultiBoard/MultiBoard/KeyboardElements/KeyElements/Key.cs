using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;

namespace MultiBoard.KeyboardElements.KeyElements
{
    public class Key
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        //variables
        //===============================
        const int _KEYUP = 0x0002;
        const int _KEYDOWN = 0x0001;

        private bool _onKeyDownSelected = false;
        private bool _onKeyUpSelected = false;
        private bool _onKeyPressedSelected = false;

        private string _keyName;
        private bool _recordingKey = false;
        private bool _enabled = true;
        private string _keyTag;
        private string _executeLocation;

        private Timer _timer = new Timer();
        private int _keyPressCount = 0;
        private const int _defInterval = 300;

        /// <summary>
        /// a key that is connected to a keyboard and handles key events
        /// </summary>
        /// <param name="name">
        /// The name of the key shown to the user
        /// </param>
        /// <param name="eventStateAr">
        /// On which event the key must react
        /// </param>
        /// <param name="key">
        /// The key code
        /// </param>
        /// <param name="enabledKey">
        /// Is the key enabled
        /// </param>
        /// <param name="executeLoc">
        /// The action or location of file to open
        /// </param>
        public Key(string name, int eventStateAr, string key, bool enabledKey, string executeLoc)
        {
            _keyName = name;
            EventState = eventStateAr;
            _keyTag = key;
            _enabled = enabledKey;
            _executeLocation = executeLoc;

            _timer.Interval = _defInterval;
            _timer.Elapsed += timerOnElapsed;
            _timer.Stop();
        }

        /// <summary>
        /// Handles the key pressed event timing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOnElapsed(object sender, EventArgs e)
        {
            if (_timer.Interval == _defInterval)
            {
                _timer.Interval = 200;
            }

            if (_timer.Interval != _defInterval)
            {
                _keyPressCount++;
                int newInter = 200 - _keyPressCount * 20;
                if (newInter > 50)
                {
                    _timer.Interval = newInter;
                }
            }

            executeFile();

        }

        /// <summary>
        /// The name of the key shown to the user
        /// </summary>
        public string key_name
        {
            get
            {
                return _keyName;
            }
            set
            {
                _keyName = value;
            }
        }

        /// <summary>
        /// On which event the key must react
        /// </summary>
        public int EventState
        {
            get
            {
                if(_onKeyDownSelected == true)
                {
                    return 1;
                }
                else if(_onKeyUpSelected == true)
                {
                    return 2;
                }
                else if(_onKeyPressedSelected == true)
                {
                    return 3;
                }
                return 0;
            }

            set
            {
                _timer.Stop();
                if(value == 1)
                {
                    _onKeyDownSelected = true;
                    _onKeyUpSelected = false;
                    _onKeyPressedSelected = false;
                }
                else if(value == 2)
                {
                    _onKeyDownSelected = false;
                    _onKeyUpSelected = true;
                    _onKeyPressedSelected = false;
                }
                else
                {
                    _onKeyDownSelected = false;
                    _onKeyUpSelected = false;
                    _onKeyPressedSelected = true;
                }
            }
        }

        /// <summary>
        /// Is the key enabled
        /// </summary>
        public bool keyEnebled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        /// <summary>
        /// The key code
        /// </summary>
        public string keyTag
        {
            get
            {
                return _keyTag;
            }
            set
            {
                _keyTag = value;
            }
        }

        /// <summary>
        /// The action or location of file to open
        /// </summary>
        public string executeLoc
        {
            get
            {
                return _executeLocation;
            }
            set
            {
                _executeLocation = value;
            }
        }

        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="key">
        /// Key code
        /// </param>
        /// <param name="allEnebled">
        /// Is key allowed to run
        /// </param>
        public void keyDown(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyDownSelected && allEnebled)
                {
                    //execute
                    executeFile();
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    executeFile();
                    _timer.Start();
                }
            }
        }

        /// <summary>
        /// The key up event
        /// </summary>
        /// <param name="key">
        /// Key code
        /// </param>
        /// <param name="allEnebled">
        /// Is key allowed to run
        /// </param>
        public void keyUp(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyUpSelected && allEnebled)
                {
                    executeFile();
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    _timer.Stop();
                    _timer.Interval = _defInterval;
                    _keyPressCount = 0;
                }
            }
        }

        /// <summary>
        /// Execute the task of the key
        /// </summary>
        private void executeFile()
        {
            if (_executeLocation.Replace("<", "") != _executeLocation)
            {
                string key = executeLoc.Replace("<" , "").Replace(">", "");
                keybd_event(getVkKey(key), 0, _KEYDOWN, 0);
                keybd_event(getVkKey(key), 0, _KEYUP, 0);
            }
            else
            {
                if (File.Exists(_executeLocation))
                {
                    //execute
                    System.Diagnostics.Process.Start(_executeLocation);
                }
                else
                {
                    Properties.Settings.Default.ErrorList += ", execute file not found --> " + _keyName;
                }
            }
        }

        /// <summary>
        /// Convert vk name to vk byte code
        /// </summary>
        /// <param name="keyCode">
        /// Name of the key
        /// </param>
        /// <returns>
        /// The byte of the key
        /// </returns>
        private byte getVkKey(string keyCode)
        {
            //Numbers
            if(keyCode == "0")
            {
                return 0x30;
            }
            else if (keyCode == "1")
            {
                return 0x31;
            }
            else if (keyCode == "2")
            {
                return 0x32;
            }
            else if (keyCode == "3")
            {
                return 0x33;
            }
            else if (keyCode == "4")
            {
                return 0x34;
            }
            else if (keyCode == "5")
            {
                return 0x35;
            }
            else if (keyCode == "6")
            {
                return 0x36;
            }
            else if (keyCode == "7")
            {
                return 0x37;
            }
            else if (keyCode == "8")
            {
                return 0x38;
            }
            else if (keyCode == "9")
            {
                return 0x39;
            }
            //Chars
            else if (keyCode == "A")
            {
                return 0x41;
            }
            else if (keyCode == "B")
            {
                return 0x42;
            }
            else if (keyCode == "C")
            {
                return 0x43;
            }
            else if (keyCode == "D")
            {
                return 0x44;
            }
            else if (keyCode == "E")
            {
                return 0x45;
            }
            else if (keyCode == "F")
            {
                return 0x46;
            }
            else if (keyCode == "G")
            {
                return 0x47;
            }
            else if (keyCode == "H")
            {
                return 0x48;
            }
            else if (keyCode == "I")
            {
                return 0x49;
            }
            else if (keyCode == "J")
            {
                return 0x4a;
            }
            else if (keyCode == "K")
            {
                return 0x4b;
            }
            else if (keyCode == "L")
            {
                return 0x4c;
            }
            else if (keyCode == "M")
            {
                return 0x4d;
            }
            else if (keyCode == "N")
            {
                return 0x4e;
            }
            else if (keyCode == "O")
            {
                return 0x4f;
            }
            else if (keyCode == "P")
            {
                return 0x50;
            }
            else if (keyCode == "Q")
            {
                return 0x51;
            }
            else if (keyCode == "R")
            {
                return 0x52;
            }
            else if (keyCode == "S")
            {
                return 0x53;
            }
            else if (keyCode == "T")
            {
                return 0x54;
            }
            else if (keyCode == "U")
            {
                return 0x55;
            }
            else if (keyCode == "V")
            {
                return 0x56;
            }
            else if (keyCode == "W")
            {
                return 0x57;
            }
            else if (keyCode == "X")
            {
                return 0x58;
            }
            else if (keyCode == "Y")
            {
                return 0x59;
            }
            else if (keyCode == "Z")
            {
                return 0x5a;
            }
            //F keys
            else if (keyCode == "F1")
            {
                return 0x70;
            }
            else if (keyCode == "F2")
            {
                return 0x71;
            }
            else if (keyCode == "F3")
            {
                return 0x72;
            }
            else if (keyCode == "F4")
            {
                return 0x73;
            }
            else if (keyCode == "F5")
            {
                return 0x74;
            }
            else if (keyCode == "F6")
            {
                return 0x75;
            }
            else if (keyCode == "F7")
            {
                return 0x76;
            }
            else if (keyCode == "F8")
            {
                return 0x77;
            }
            else if (keyCode == "F9")
            {
                return 0x78;
            }
            else if (keyCode == "F10")
            {
                return 0x79;
            }
            else if (keyCode == "F11")
            {
                return 0x7a;
            }
            else if (keyCode == "F12")
            {
                return 0x7b;
            }
            else if(keyCode =="F13")
            {
                return 0x7c;
            }
            else if (keyCode == "F14")
            {
                return 0x7d;
            }
            else if (keyCode == "F15")
            {
                return 0x7e;
            }
            else if (keyCode == "F16")
            {
                return 0x7f;
            }
            else if (keyCode == "F17")
            {
                return 0x80;
            }
            else if (keyCode == "F18")
            {
                return 0x81;
            }
            else if (keyCode == "F19")
            {
                return 0x82;
            }
            else if (keyCode == "F20")
            {
                return 0x83;
            }
            else if (keyCode == "F21")
            {
                return 0x84;
            }
            else if (keyCode == "F22")
            {
                return 0x85;
            }
            else if (keyCode == "F23")
            {
                return 0x86;
            }
            else if (keyCode == "F24")
            {
                return 0xFB;
            }
            //Undefined keys
            else if (keyCode == "UND1")
            {
                return 0x0E;
            }
            else if (keyCode == "UND2")
            {
                return 0x0F;
            }
            else if (keyCode == "UND3")
            {
                return 0x16;
            }
            else if (keyCode == "UND4")
            {
                return 0x1A;
            }
            else if (keyCode == "UND5")
            {
                return 0x3A;
            }
            else if (keyCode == "UND6")
            {
                return 0x3B;
            }
            else if (keyCode == "UND7")
            {
                return 0x3C;
            }
            else if (keyCode == "UND8")
            {
                return 0x3D;
            }
            else if (keyCode == "UND9")
            {
                return 0x3E;
            }
            else if (keyCode == "UND10")
            {
                return 0x3F;
            }
            else if (keyCode == "UND11")
            {
                return 0x40;
            }

            return 0x00;
        }
    }
}
