using System;
using System.IO;
using System.Timers;

namespace MultiBoard.KeyboardElements.KeyElements
{
    public class Key
    {
        //variables
        //===============================
        private bool _onKeyDownSelected = false;
        private bool _onKeyUpSelected = false;
        private bool _onKeyPressedSelected = false;

        private string _keyName;
        private bool _recordingKey = false;
        private bool _enabled = true;
        private string _keyTag;
        private string _executeLocation;

        private Timer _timer = new Timer();

        public Key(string name, int eventStateAr, string key, bool enabledKey, string executeLoc)
        {
            _keyName = name;
            EventState = eventStateAr;
            _keyTag = key;
            _enabled = enabledKey;
            _executeLocation = executeLoc;

            _timer.Interval = 500;
            _timer.Elapsed += timerOnElapsed;
            _timer.Stop();
        }

        private void timerOnElapsed(object sender, EventArgs e)
        {
            if (_timer.Interval == 500)
            {
                _timer.Interval = 200;
            }

            if (File.Exists(_executeLocation))
            {
                //execute
                System.Diagnostics.Process.Start(_executeLocation);
            }

        }

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

        public void keyDown(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyDownSelected && File.Exists(_executeLocation) && allEnebled)
                {
                    //execute
                    System.Diagnostics.Process.Start(_executeLocation);
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    _timer.Start();
                }
            }
        }

        public void keyUp(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyUpSelected && File.Exists(_executeLocation) && allEnebled)
                {
                    //execute
                    System.Diagnostics.Process.Start(_executeLocation);
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    _timer.Stop();
                }
            }
        }
    }
}
