using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoardKeyboard
{
    public class JTask
    {
        public List<String> AhkScriptNameAndArgs;
        public string OneLineAhkScript;
        public string StaticAhkScriptFromFile;
        public string PushKey;
        public string OpenFile;
    }

    public class JKey
    {
        public JTask Task;
        public string KeyName;
        public bool Enabled = true;
        public string KeyTag;
        public string ExecuteLocation;
        public int KeyState = 0;
    }
    public class JKeyboard
    {
        public string Version;

        public string Id;
        public string Name;
        public string ComPort;
        public List<JKey> KeyList = new List<JKey>();
    }
}
