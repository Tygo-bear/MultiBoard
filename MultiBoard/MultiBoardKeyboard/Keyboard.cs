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

        public List<Key> KeyboardKeyList
        {
            get { return _keyList; }
        }

        public string KeyboardName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string KeyboardUuid
        {
            get { return _id; }
            set { _id = value; }
        }

        public string KeyboardComPort
        {
            get { return _comPort; }
            set { _comPort = value; }
        }

        public int NumberOfKeys
        {
            get { return _numberOfKeys; }
            set { _numberOfKeys = value; }
        }

        public int ConnectTimeoutDelay
        {
            get { return _connectTimeoutDelay; }
            set { _connectTimeoutDelay = value; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }


        public Key CreateKey(string keyName, int eventState, string keyTag, bool keyEnabled, string exeLoc)
        {

            Key obj = new Key(keyName, eventState, keyTag, keyEnabled, exeLoc);

            _numberOfKeys++;
            _keyList.Add(obj);

            return obj;
        }

        public Key AddKey(Key k)
        {
            _keyList.Add(k);
            _numberOfKeys++;
            return k;
        }

        public bool RemoveKey(Key k)
        {
            return _keyList.Remove(k);
        }

        public bool ConnectorReady()
        {
            return _comPort.ToUpper().Contains("COM") && !String.IsNullOrEmpty(_staticId) && !String.IsNullOrEmpty(KeyboardUuid);
        }

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

            _comConnector.closePort();
            _comConnector.setup(_comPort, _bRate);
            _comConnector.openPort();
            return true;
        }

        private void ComConnectorOnKeyUp(object sender, KeyEventArgs e)
        {
            keyUp(e.Key, KeyboardUuid, _enabled);
        }

        private void ComConnectorOnKeyDown(object sender, KeyEventArgs e)
        {
            keyDown(e.Key, KeyboardUuid, _enabled);
        }

        public bool DisConnect()
        {
            if (_comConnector == null)
            {
                return false;
            }

            _comConnector.closePort();
            return true;
        }

        public bool ReConnect()
        {
            if (_comConnector == null)
            {
                return false;
            }

            _comConnector.reConnect();
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

        public void loadKeys(string keys, bool add = false)
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

        public void keyDown(string key, string keyboardUuid, bool allEnabled = true)
        {
            //check for matching ids
            if (keyboardUuid == _id)
            {
                //send to all keys
                foreach (Key aKey in _keyList)
                {
                    aKey.keyDown(key, allEnabled);
                }

                OnReceivedKeyDown(key);
            }
        }


        public void keyUp(string key, string keyboardUuid, bool allEnabled = true)
        {
            //check for matching ids
            if (keyboardUuid == _id)
            {
                //send to all keys
                foreach (Key aKey in _keyList)
                {
                    aKey.keyUp(key, allEnabled);
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


        protected virtual void OnReceivedKeyUp(string e)
        {
            ReceivedKeyUp?.Invoke(this, e);
        }

        protected virtual void OnReceivedKeyDown(string e)
        {
            ReceivedKeyDown?.Invoke(this, e);
        }
    }
}
