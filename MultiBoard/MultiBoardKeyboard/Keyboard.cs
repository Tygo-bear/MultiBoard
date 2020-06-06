using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiBoard.KeyboardElements.KeyElements;

namespace MultiBoard.KeyboardElements
{
    public class Keyboard
    {
        //Vars
        //=============
        private string _id;
        private string _name;
        private string _comPort;

        private List<Key> _keyList = new List<Key>();
        private List<string> _keyNameList = new List<string>();

        private int _numberOfKeys = 0;
        

        //Events
        //=============
        public event EventHandler<string> ReceivedKeyDown;
        public event EventHandler<string> ReceivedKeyUp;

        public Keyboard()
        {

        }

        public List<Key> KeyboardKeylist
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

        public int NumerOfKeys
        {
            get { return _numberOfKeys; }
            set { _numberOfKeys = value; }
        }

        /// <summary>
        /// Create a new key
        /// </summary>
        /// <param name="keyName">
        /// Uuid of the key
        /// </param>
        /// <param name="eventState">
        /// The event on which the key reacts
        /// </param>
        /// <param name="keyTag">
        /// The key code
        /// </param>
        /// <param name="keyEnabled">
        /// Is the key enabled
        /// </param>
        /// <param name="exeLoc">
        /// The task of the key (open file/press key)
        /// </param>
        /// <returns>
        /// Return the generated class
        /// </returns>
        public Key createKey(string keyName, int eventState, string keyTag, bool keyEnabled, string exeLoc)
        {

            Key obj = new Key(keyName, eventState, keyTag, keyEnabled, exeLoc);

            _numberOfKeys++;
            _keyList.Add(obj);

            return obj;
        }

        public Key addKey(Key k)
        {
            _keyList.Add(k);
            _numberOfKeys++;
            return k;
        }

        public bool removeKey(Key k)
        {
            return _keyList.Remove(k);
        }

        /// <summary>
        /// Check the key Uuid of dupes
        /// </summary>
        /// <param name="s">
        /// The name to check for
        /// </param>
        /// <returns>
        /// True = valid
        /// False = invalid
        /// </returns>
        public bool checkNameAvailable(string s)
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

        /// <summary>
        /// Load the keys into the keyboard class
        /// </summary>
        /// <param name="mainDirectory">
        /// The main directory of the program
        /// </param>
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
                    Key k = createKey(splits[0], Int32.Parse(splits[1]), splits[2], Convert.ToBoolean(splits[3]), splits[4]);
                    counter++;
                }
            }

            updateKeyNameList();
        }

        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="key">
        /// Key code
        /// </param>
        /// <param name="keyboardUuid">
        /// dynamic id of the keyboard
        /// </param>
        /// <param name="allEnabled">
        /// Is key allowed to run
        /// </param>
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

        /// <summary>
        /// Key up event
        /// </summary>
        /// <param name="key">
        /// Key code
        /// </param>
        /// <param name="keyboardUuid">
        /// dynamic id of the keyboard
        /// </param>
        /// <param name="allEnabled">
        /// Is key allowed to run
        /// </param>
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

        /// <summary>
        /// Update the list of the names from all the keys
        /// </summary>
        public void updateKeyNameList()
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
