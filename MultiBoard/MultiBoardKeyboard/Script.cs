using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoHotkey.Interop;

namespace MultiBoardKeyboard
{
    public class Script
    {
        private AutoHotkeyEngine _ahkEngine = AutoHotkeyEngine.Instance;
        public bool IsRunning = false;
        public string ScriptLabel;

        public bool LoadScript(string path)
        {
            if (File.Exists(path))
            {
                _ahkEngine.Terminate();
                _ahkEngine.LoadFile(path);
                IsRunning = true;
                return true;
            }

            return false;
        }

        public void TerminateScript()
        {
            _ahkEngine.Terminate();
            IsRunning = false;
        }

        public string ExecuteFunction(string funcName, List<string> args)
        {
            switch (args.Count)
            {
                case 0:
                    return _ahkEngine.ExecFunction(funcName);
                case 1:
                    return _ahkEngine.ExecFunction(funcName, args[0]);
                case 2:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1]);
                case 3:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2]);
                case 4:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3]);
                case 5:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3], args[4]);
                case 6:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3], args[4], args[5]);
                case 7:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3], args[4], args[5], 
                        args[6]);
                case 8:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3], args[4], args[5], 
                        args[6], args[7]);
                case 9:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3], args[4], args[5], 
                        args[6], args[7], args[8]);
                case 10:
                    return _ahkEngine.ExecFunction(funcName, args[0], args[1], args[2], args[3], args[4], args[5], 
                        args[6], args[7], args[8], args[9]);
            }

            return "";
        }
    }
}
