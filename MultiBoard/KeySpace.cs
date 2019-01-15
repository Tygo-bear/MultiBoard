using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoard
{
    class KeySpace
    {
        public string[] keys;
        public bool[] state;

        public void keyDown(string key)
        {
            for(int i =0; i < keys.Length; i++)
            {
                if(keys[i] == key)
                {
                    state[i] = true;
                    return;
                }
            }
            keys[keys.Length] = key;
            state[keys.Length] = true;
        }

        public void keyUp(string key)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == key)
                {
                    state[i] = false;
                    return;
                }
            }
            keys[keys.Length] = key;
            state[keys.Length] = false;
        }

        public void emtySpace()
        {
            keys = null;
            state = null;
        }

    }
}
