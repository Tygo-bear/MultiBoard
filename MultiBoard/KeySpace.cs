using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBoard
{
    class KeySpace
    {
        public List<string> keys = new List<string>();
        public List<bool> state = new List<bool>();

        public void keyDown(string key)
        {
            int teller = 0;
            foreach(string k in keys)
            {
                if(k == key)
                {
                    state[teller] = true;
                    return;
                }
                teller++;
            }
            keys.Add(key);
            state.Add(true);
        }

        public void keyUp(string key)
        {
            int teller = 0;
            foreach (string k in keys)
            {
                if (k == key)
                {
                    state[teller] = false;
                    return;
                }
                teller++;
            }
            keys.Add(key);
            state.Add(false);
        }

        public void emtySpace()
        {
            keys.Clear();
            state.Clear();
        }

    }
}
