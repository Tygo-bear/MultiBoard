using System.Collections.Generic;

namespace MultiBoard
{
    class KeySpace
    {
        public List<string> Keys = new List<string>();
        public List<bool> State = new List<bool>();

        public void keyDown(string key)
        {
            int teller = 0;
            foreach(string k in Keys)
            {
                if(k == key)
                {
                    State[teller] = true;
                    return;
                }
                teller++;
            }
            Keys.Add(key);
            State.Add(true);
        }

        public void keyUp(string key)
        {
            int teller = 0;
            foreach (string k in Keys)
            {
                if (k == key)
                {
                    State[teller] = false;
                    return;
                }
                teller++;
            }
            Keys.Add(key);
            State.Add(false);
        }

        public void emtySpace()
        {
            Keys.Clear();
            State.Clear();
        }

    }
}
