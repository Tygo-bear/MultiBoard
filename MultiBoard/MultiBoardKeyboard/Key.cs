using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;
using AutoHotkey.Interop;

namespace MultiBoardKeyboard
{
    public class Key
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public event EventHandler<string> Error; 

        //variables
        //===============================

        private bool _onKeyDownSelected = false;
        private bool _onKeyUpSelected = false;
        private bool _onKeyPressedSelected = false;

        private string _keyName;
        private bool _recordingKey = false;
        private bool _enabled = true;
        private string _keyTag;

        private KeyTask _keyTask;
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
            _keyTask = new KeyTask();

            MigrateToTask();
            _timer.Interval = _defInterval;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Stop();
        }

        public Key(string name, int eventStateAr, string key, bool enabledKey, KeyTask task)
        {
            _keyName = name;
            EventState = eventStateAr;
            _keyTag = key;
            _enabled = enabledKey;
            _keyTask = task;

            _timer.Interval = _defInterval;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Stop();
        }

        public Key(JKey jk)
        {
            _keyName = jk.KeyName;
            EventState = jk.KeyState;
            _keyTag = jk.KeyTag;
            _enabled = jk.Enabled;
            _executeLocation = jk.ExecuteLocation;
            _keyTask = new KeyTask(jk.Task);

            if (jk.Task == null)
                MigrateToTask();

            _timer.Interval = _defInterval;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Stop();
        }

        private void MigrateToTask()
        {
            if (_executeLocation.Replace("<", "") != _executeLocation)
            {
                string key = _executeLocation.Replace("<", "").Replace(">", "");
                _keyTask.PushKey = key;
            }
            else if (_executeLocation.Replace("?", "") != _executeLocation)
            {
                string loc = _executeLocation.Replace("?", "");
                _keyTask.StaticAhkScriptFromFile = loc;
            }
            else if (_executeLocation.Replace("{", "") != _executeLocation)
            {
                string temp = "SendInput, " + _executeLocation.Remove(0, 1);
                temp = temp.Remove(temp.Length - 1, 1);
                _keyTask.OneLineAhkScript = temp;
            }
            else
            {
                _keyTask.OpenFile = _executeLocation;
            }
        }

        /// <summary>
        /// Handles the key pressed event timing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerOnElapsed(object sender, EventArgs e)
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

            ExecuteFile();

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
                if(_onKeyDownSelected)
                {
                    return 1;
                }
                else if(_onKeyUpSelected)
                {
                    return 2;
                }
                else if(_onKeyPressedSelected)
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
        public bool KeyEnabled
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
                _keyTask.StaticAhkScriptFromFile = value;

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
        public void KeyDown(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyDownSelected && allEnebled)
                {
                    //execute
                    ExecuteFile();
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    ExecuteFile();
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
        public void KeyUp(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyUpSelected && allEnebled)
                {
                    ExecuteFile();
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
        private void ExecuteFile()
        {
            _keyTask.ExecuteTask();
        }

        protected virtual void OnError(string e)
        {
            Error?.Invoke(this, e);
        }

        public JKey SaveKey()
        {
            JKey jk = new JKey();
            jk.KeyName = _keyName;
            jk.Enabled = _enabled;
            jk.KeyTag = _keyTag;
            jk.ExecuteLocation = _executeLocation;
            jk.KeyState = EventState;
            jk.Task =_keyTask.SaveTask();

            return jk;
        }
    }

    public class KeyTask
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        const int _KEYUP = 0x0002;
        const int _KEYDOWN = 0x0001;
        private AutoHotkeyEngine _ahk = AutoHotkeyEngine.Instance;

        public string OneLineAhkScript;

        private string _staticAhkScriptFromFile;
        private string _staticAhkScriptFromFileCash;

        public string PushKey;
        public string OpenFile;

        public KeyTask()
        {

        }

        public KeyTask(JKeyTask j)
        {
            if (j != null)
            {
                OneLineAhkScript = j.OneLineAhkScript;
                StaticAhkScriptFromFile = j.StaticAhkScriptFromFile;
                PushKey = j.PushKey;
                OpenFile = j.OpenFile;
            }
        }

        public JKeyTask SaveTask()
        {
            JKeyTask j = new JKeyTask();
            j.OneLineAhkScript = OneLineAhkScript;
            j.OpenFile = OpenFile;
            j.PushKey = PushKey;
            j.StaticAhkScriptFromFile = StaticAhkScriptFromFile;

            return j;
        }

        public string StaticAhkScriptFromFile
        {
            get { return _staticAhkScriptFromFile; }
            set
            {
                _staticAhkScriptFromFile = value;
                if (File.Exists(value))
                {
                    _staticAhkScriptFromFileCash = File.ReadAllText(value);
                }
                else
                {
                    //TODO report error
                    //OnError("ahk read error, script not found --> " + value);
                }
            }
        }

        public void ExecuteTask()
        {
            if (OneLineAhkScript != null)
            {
                if (!String.IsNullOrEmpty(OneLineAhkScript))
                {
                    _ahk.ExecRaw(OneLineAhkScript);
                    _ahk.Reset();
                }
            }
            else if (_staticAhkScriptFromFile != null)
            {
                if (!String.IsNullOrEmpty(_staticAhkScriptFromFileCash))
                {
                    _ahk.ExecRaw(_staticAhkScriptFromFileCash);
                    _ahk.Reset();
                }
            }
            else if (PushKey != null)
            {
                keybd_event(VkKey.getVkKey(PushKey), 0, _KEYDOWN, 0);
                keybd_event(VkKey.getVkKey(PushKey), 0, _KEYUP, 0);
            }
            else if (OpenFile != null)
            {
                if (File.Exists(OpenFile))
                {
                    //TODO run args
                    //execute
                    System.Diagnostics.Process.Start(OpenFile);
                }
                else
                {
                    //TODO report error
                    //OnError("execute file not found --> " + _keyName);
                }
            }
        }

        public override string ToString()
        {
            if (OneLineAhkScript != null)
                return OneLineAhkScript;
            
            if (_staticAhkScriptFromFile != null)
                return StaticAhkScriptFromFile;
            
            if (PushKey != null)
                return PushKey;
            
            if (OpenFile != null)
                return OpenFile;
            
            return "No Task selected";
        }
    }
}
