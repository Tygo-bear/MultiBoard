using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoard.Keyboard.Key
{
    public class Key
    {
        //variables
        //===============================
        private bool OnKeyDownSelected = false;
        private bool OnKeyUpSelected = false;
        private bool OnKeyPressedSelected = false;

        private string keyName;
        private bool recordingKey = false;
        private bool enabled = true;
        private string KeyTag;
        private string ExecuteLocation;

        public Key(string name, int eventStateAr, string key, bool enabledKey, string executeLoc)
        {
            keyName = name;
            eventState = eventStateAr;
            KeyTag = key;
            enabled = enabledKey;
            ExecuteLocation = executeLoc;
        }

        public string key_name
        {
            get
            {
                return keyName;
            }
            set
            {
                keyName = value;
            }
        }

        public int eventState
        {
            get
            {
                if(OnKeyDownSelected == true)
                {
                    return 1;
                }
                else if(OnKeyUpSelected == true)
                {
                    return 2;
                }
                else if(OnKeyPressedSelected == true)
                {
                    return 3;
                }
                return 0;
            }

            set
            {
                if(value == 1)
                {
                    OnKeyDownSelected = true;
                    OnKeyUpSelected = false;
                    OnKeyPressedSelected = false;
                }
                else if(value == 2)
                {
                    OnKeyDownSelected = false;
                    OnKeyUpSelected = true;
                    OnKeyPressedSelected = false;
                }
                else
                {
                    OnKeyDownSelected = false;
                    OnKeyUpSelected = false;
                    OnKeyPressedSelected = true;
                }
            }
        }

        public bool keyEnebled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        public string keyTag
        {
            get
            {
                return KeyTag;
            }
            set
            {
                KeyTag = value;
            }
        }

        public string executeLoc
        {
            get
            {
                return ExecuteLocation;
            }
            set
            {
                ExecuteLocation = value;
            }
        }

        public void keyDown(string KEY, bool allEnebled)
        {
            if (recordingKey == false)
            {
                if (KeyTag == KEY && enabled == true && OnKeyDownSelected && File.Exists(ExecuteLocation) && allEnebled)
                {
                    //execute
                    System.Diagnostics.Process.Start(ExecuteLocation);
                }
            }
        }

        public void keyUp(string KEY, bool allEnebled)
        {
            if (recordingKey == false)
            {
                if (KeyTag == KEY && enabled == true && OnKeyUpSelected && File.Exists(ExecuteLocation) && allEnebled)
                {
                    //execute
                    System.Diagnostics.Process.Start(ExecuteLocation);
                }

            }
        }
    }
}
