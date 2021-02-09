using System;
using System.Collections.Generic;
using MultiBoard.KeyboardElements.KeyElements;

namespace MultiBoardKeyboard
{
    public class Keyboard
    {
        //Vars
        //=============
        private string _id;
        private string _name;
        private string _comPort;
        private string _staticId;
        private int _connectTimeoutDelay = 6000;
        private int _bRate = 115200;
        private bool _enabled = true;

        private List<Key> _keyList = new List<Key>();
        private List<string> _keyNameList = new List<string>();
        private Connector _comConnector;


        private int _numberOfKeys = 0;
        

        //Events
        //=============
        public event EventHandler<string> ReceivedKeyDown;
        public event EventHandler<string> ReceivedKeyUp;

        public Keyboard(string staticId)
        {
            _staticId = staticId;
        }

        public Keyboard(JKeyboard jk, string staticId)
        {
            _id = jk.Id;
            _name = jk.Name;
            _comPort = jk.ComPort;
            _staticId = staticId;

            foreach (JKey jKey in jk.KeyList)
            {
                Key k = new Key(jKey);
                _keyList.Add(k);
            }
        }

        /// <summary>
        /// List of keys declared in the keyboard
        /// </summary>
        public List<Key> KeyboardKeyList
        {
            get { return _keyList; }
        }

        /// <summary>
        /// Name of the keyboard
        /// </summary>
        public string KeyboardName
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// UUID of the keyboard
        /// </summary>
        public string KeyboardUuid
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// COM port on which the keyboard is connected
        /// </summary>
        public string KeyboardComPort
        {
            get { return _comPort; }
            set { _comPort = value; }
        }

        /// <summary>
        /// Total amount of declared keys
        /// </summary>
        public int NumberOfKeys
        {
            get { return _numberOfKeys; }
            set { _numberOfKeys = value; }
        }

        /// <summary>
        /// Set connection timeout delay
        /// </summary>
        public int ConnectTimeoutDelay
        {
            get { return _connectTimeoutDelay; }
            set { _connectTimeoutDelay = value; }
        }

        /// <summary>
        /// Keyboard enabled
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        /// Declare a new key in the keyboard
        /// </summary>
        /// <param name="keyName">Name of the key</param>
        /// <param name="eventState">Which event to trigger on</param>
        /// <param name="keyTag">Physical key tag</param>
        /// <param name="keyEnabled">Key enabled</param>
        /// <param name="exeLoc">Action (legacy)</param>
        /// <returns></returns>
        public Key CreateKey(string keyName, int eventState, string keyTag, bool keyEnabled, string exeLoc)
        {

            Key obj = new Key(keyName, eventState, keyTag, keyEnabled, exeLoc);

            _numberOfKeys++;
            _keyList.Add(obj);

            return obj;
        }

        /// <summary>
        /// Add key to declared keys
        /// </summary>
        /// <param name="k">Key to add</param>
        /// <returns></returns>
        public Key AddKey(Key k)
        {
            _keyList.Add(k);
            _numberOfKeys++;
            return k;
        }

        /// <summary>
        /// Remove key from declaration
        /// </summary>
        /// <param name="k">Key to remove</param>
        /// <returns></returns>
        public bool RemoveKey(Key k)
        {
            return _keyList.Remove(k);
        }

        /// <summary>
        /// Correct connection param
        /// </summary>
        /// <returns>true/false</returns>
        public bool ConnectorReady()
        {
            if (!String.IsNullOrEmpty(_comPort))
            {
                return _comPort.ToUpper().Contains("COM") && !String.IsNullOrEmpty(_staticId) &&
                       !String.IsNullOrEmpty(KeyboardUuid);
            }

            return false;
        }

        /// <summary>
        /// Connect keyboard to COM
        /// </summary>
        /// <returns>Can connect</returns>
        public bool Connect()
        {
            if (_comConnector == null)
            {
                if (ConnectorReady())
                {
                    _comConnector = new Connector(_staticId, _connectTimeoutDelay);
                    _comConnector.KeyDown += ComConnectorOnKeyDown;
                    _comConnector.KeyUp += ComConnectorOnKeyUp;
                }
                else
                {
                    //TODO Error message
                    return false;
                }
            }

            _comConnector.ClosePort();
            _comConnector.Setup(_comPort, _bRate);
            _comConnector.OpenPort();
            return true;
        }

        private void ComConnectorOnKeyUp(object sender, KeyEventArgs e)
        {
            KeyUp(e.Key, KeyboardUuid, _enabled);
        }

        private void ComConnectorOnKeyDown(object sender, KeyEventArgs e)
        {
            KeyDown(e.Key, KeyboardUuid, _enabled);
        }

        public bool DisConnect()
        {
            if (_comConnector == null)
            {
                return false;
            }

            _comConnector.ClosePort();
            return true;
        }

        public bool ReConnect()
        {
            if (_comConnector == null)
            {
                return false;
            }

            _comConnector.ReConnect();
            return true;
        }


        public bool CheckNameAvailable(string s)
        {
            foreach (string n in _keyNameList)
            {
                if (n == s)
                {
                    return false;
                }
            }
            return true;
        }

        public void LoadKeys(string keys, bool add = false)
        {
            if (add)
            {
                _keyList.Clear();
            }

            var counter = 0;
            string[] lines = keys.Replace("\r", "").Split('\n');
            foreach (string s in lines)
            {
                
                if (s != "")
                {
                    string[] splits =s.Split('|');
                    Key k = CreateKey(splits[0], Int32.Parse(splits[1]), splits[2], Convert.ToBoolean(splits[3]), splits[4]);
                    counter++;
                }
            }

            UpdateKeyNameList();
        }

        public void KeyDown(string key, string keyboardUuid, bool allEnabled = true)
        {
            //check for matching ids
            if (keyboardUuid == _id)
            {
                //send to all keys
                foreach (Key aKey in _keyList)
                {
                    aKey.KeyDown(key, allEnabled);
                }

                OnReceivedKeyDown(key);
            }
        }


        public void KeyUp(string key, string keyboardUuid, bool allEnabled = true)
        {
            //check for matching ids
            if (keyboardUuid == _id)
            {
                //send to all keys
                foreach (Key aKey in _keyList)
                {
                    aKey.KeyUp(key, allEnabled);
                }
            }

            OnReceivedKeyUp(key);
        }

        public void UpdateKeyNameList()
        {
            _keyNameList.Clear();
            foreach (Key k in _keyList)
            {
                _keyNameList.Add(k.key_name);
            }

        }

        public void UpdateScripts(List<Script> scripts)
        {
            foreach (Key key in KeyboardKeyList)
            {
                key.KeyMTask.AssignScript(scripts);
            }
        }


        protected virtual void OnReceivedKeyUp(string e)
        {
            ReceivedKeyUp?.Invoke(this, e);
        }

        protected virtual void OnReceivedKeyDown(string e)
        {
            ReceivedKeyDown?.Invoke(this, e);
        }

        public JKeyboard SaveKeyboard(string version)
        {
            JKeyboard jk = new JKeyboard();
            jk.Version = version;
            jk.Id = _id;
            jk.Name = _name;
            jk.ComPort = _comPort;

            foreach (Key key in _keyList)
            {
                jk.KeyList.Add(key.SaveKey());
            }

            return jk;
        }
    }
}
