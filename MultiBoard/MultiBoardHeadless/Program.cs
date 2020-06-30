using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultiBoardKeyboard;

namespace MultiBoardHeadless
{
    class Program
    {
        static void Main(string[] args)
        {
            string _staticId = "86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1";

            Keyboard keyboard = new Keyboard(_staticId);
            keyboard.KeyboardUuid = "7fba9a6d-61d1-4973-a68e-41a26309b48e";
            keyboard.KeyboardComPort = "com12";
            keyboard.Connect();
            keyboard.CreateKey("test", 0, ">2C<",true, "{{LWin down}{d}{LWin up}}");
            while (true)
            {
                Thread.Sleep(1);
            }
        }
    }
}
