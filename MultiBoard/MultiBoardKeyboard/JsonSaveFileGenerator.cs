﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoardKeyboard
{
    public class JKeyTask
    {
        public string OneLineAhkScript;
        public string StaticAhkScriptFromFile;
        public string PushKey;
        public string OpenFile;
        public string OpenFileArgs;
    }
    public class JKey
    {
        public string KeyName;
        public bool Enabled = true;
        public string KeyTag;
        public string ExecuteLocation;
        public int KeyState = 0;
        public JKeyTask Task;
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
