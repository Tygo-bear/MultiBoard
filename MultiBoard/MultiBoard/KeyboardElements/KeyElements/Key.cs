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
        const int _KEYDOWN = 0x0100;

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
                keybd_event(getVkkey(key), 0, _KEYDOWN, 0); 
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
        private byte getVkkey(string keyCode)
        {
            if(keyCode =="F13")
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
                return 0x87;
            }

            return 0x87;
        }
    }
}
