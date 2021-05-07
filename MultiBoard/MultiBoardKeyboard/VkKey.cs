namespace MultiBoardKeyboard
{
    public class VkKey
    {
        public static byte getVkKey(string keyCode)
        {
            //Numbers
            if (keyCode == "0")
            {
                return 0x30;
            }
            else if (keyCode == "1")
            {
                return 0x31;
            }
            else if (keyCode == "2")
            {
                return 0x32;
            }
            else if (keyCode == "3")
            {
                return 0x33;
            }
            else if (keyCode == "4")
            {
                return 0x34;
            }
            else if (keyCode == "5")
            {
                return 0x35;
            }
            else if (keyCode == "6")
            {
                return 0x36;
            }
            else if (keyCode == "7")
            {
                return 0x37;
            }
            else if (keyCode == "8")
            {
                return 0x38;
            }
            else if (keyCode == "9")
            {
                return 0x39;
            }
            //Chars
            else if (keyCode == "A")
            {
                return 0x41;
            }
            else if (keyCode == "B")
            {
                return 0x42;
            }
            else if (keyCode == "C")
            {
                return 0x43;
            }
            else if (keyCode == "D")
            {
                return 0x44;
            }
            else if (keyCode == "E")
            {
                return 0x45;
            }
            else if (keyCode == "F")
            {
                return 0x46;
            }
            else if (keyCode == "G")
            {
                return 0x47;
            }
            else if (keyCode == "H")
            {
                return 0x48;
            }
            else if (keyCode == "I")
            {
                return 0x49;
            }
            else if (keyCode == "J")
            {
                return 0x4a;
            }
            else if (keyCode == "K")
            {
                return 0x4b;
            }
            else if (keyCode == "L")
            {
                return 0x4c;
            }
            else if (keyCode == "M")
            {
                return 0x4d;
            }
            else if (keyCode == "N")
            {
                return 0x4e;
            }
            else if (keyCode == "O")
            {
                return 0x4f;
            }
            else if (keyCode == "P")
            {
                return 0x50;
            }
            else if (keyCode == "Q")
            {
                return 0x51;
            }
            else if (keyCode == "R")
            {
                return 0x52;
            }
            else if (keyCode == "S")
            {
                return 0x53;
            }
            else if (keyCode == "T")
            {
                return 0x54;
            }
            else if (keyCode == "U")
            {
                return 0x55;
            }
            else if (keyCode == "V")
            {
                return 0x56;
            }
            else if (keyCode == "W")
            {
                return 0x57;
            }
            else if (keyCode == "X")
            {
                return 0x58;
            }
            else if (keyCode == "Y")
            {
                return 0x59;
            }
            else if (keyCode == "Z")
            {
                return 0x5a;
            }
            //F keys
            else if (keyCode == "F1")
            {
                return 0x70;
            }
            else if (keyCode == "F2")
            {
                return 0x71;
            }
            else if (keyCode == "F3")
            {
                return 0x72;
            }
            else if (keyCode == "F4")
            {
                return 0x73;
            }
            else if (keyCode == "F5")
            {
                return 0x74;
            }
            else if (keyCode == "F6")
            {
                return 0x75;
            }
            else if (keyCode == "F7")
            {
                return 0x76;
            }
            else if (keyCode == "F8")
            {
                return 0x77;
            }
            else if (keyCode == "F9")
            {
                return 0x78;
            }
            else if (keyCode == "F10")
            {
                return 0x79;
            }
            else if (keyCode == "F11")
            {
                return 0x7a;
            }
            else if (keyCode == "F12")
            {
                return 0x7b;
            }
            else if (keyCode == "F13")
            {
                return 0x7c;
            }
            else if (keyCode == "F14")
            {
                return 0x7d;
            }
            else if (keyCode == "F15")
            {
                return 0x7e;
            }
            else if (keyCode == "F16")
            {
                return 0x7f;
            }
            else if (keyCode == "F17")
            {
                return 0x80;
            }
            else if (keyCode == "F18")
            {
                return 0x81;
            }
            else if (keyCode == "F19")
            {
                return 0x82;
            }
            else if (keyCode == "F20")
            {
                return 0x83;
            }
            else if (keyCode == "F21")
            {
                return 0x84;
            }
            else if (keyCode == "F22")
            {
                return 0x85;
            }
            else if (keyCode == "F23")
            {
                return 0x86;
            }
            else if (keyCode == "F24")
            {
                return 0xFB;
            }
            //Number-pad
            else if (keyCode == "PAD_0")
            {
                return 0x60;
            }
            else if (keyCode == "PAD_1")
            {
                return 0x61;
            }
            else if (keyCode == "PAD_2")
            {
                return 0x62;
            }
            else if (keyCode == "PAD_3")
            {
                return 0x63;
            }
            else if (keyCode == "PAD_4")
            {
                return 0x64;
            }
            else if (keyCode == "PAD_5")
            {
                return 0x65;
            }
            else if (keyCode == "PAD_6")
            {
                return 0x66;
            }
            else if (keyCode == "PAD_7")
            {
                return 0x67;
            }
            else if (keyCode == "PAD_8")
            {
                return 0x68;
            }
            else if (keyCode == "PAD_9")
            {
                return 0x69;
            }
            else if (keyCode == "PAD_MULTIPLY")
            {
                return 0x6A;
            }
            else if (keyCode == "PAD_ADD")
            {
                return 0x6B;
            }
            else if (keyCode == "PAD_SEPARATOR")
            {
                return 0x6C;
            }
            else if (keyCode == "PAD_SUBTRACT")
            {
                return 0x6D;
            }
            else if (keyCode == "PAD_DECIMAL")
            {
                return 0x6E;
            }
            else if (keyCode == "PAD_DIVIDE")
            {
                return 0x6F;
            }
            else if (keyCode == "PAD_NUMLOCK")
            {
                return 0x6A;
            }
            else if (keyCode == "PAD_PRIOR")
            {
                return 0x21;
            }
            else if (keyCode == "PAD_NEXT")
            {
                return 0x22;
            }
            else if (keyCode == "PAD_END")
            {
                return 0x23;
            }
            else if (keyCode == "PAD_HOME")
            {
                return 0x24;
            }
            else if (keyCode == "PAD_LEFT")
            {
                return 0x25;
            }
            else if (keyCode == "PAD_RIGHT")
            {
                return 0x27;
            }
            else if (keyCode == "PAD_UP")
            {
                return 0x26;
            }
            else if (keyCode == "PAD_DOWN")
            {
                return 0x28;
            }
            //Alt keys
            else if (keyCode == "ALT_LBUTTON")
            {
                return 0x01;
            }
            else if (keyCode == "ALT_RBUTTON")
            {
                return 0x02;
            }
            else if (keyCode == "ALT_CANCEL")
            {
                return 0x03;
            }
            else if (keyCode == "ALT_MBUTTON")
            {
                return 0x04;
            }
            else if (keyCode == "ALT_XBUTTON1")
            {
                return 0x05;
            }
            else if (keyCode == "ALT_XBUTTON2")
            {
                return 0x06;
            }
            else if (keyCode == "ALT_BACK")
            {
                return 0x08;
            }
            else if (keyCode == "ALT_TAB")
            {
                return 0x09;
            }
            else if (keyCode == "ALT_CLEAR")
            {
                return 0x0C;
            }
            else if (keyCode == "ALT_RETURN")
            {
                return 0x0D;
            }
            else if (keyCode == "ALT_SHIFT")
            {
                return 0x10;
            }
            else if (keyCode == "ALT_CONTROL")
            {
                return 0x11;
            }
            else if (keyCode == "ALT_MENU")
            {
                return 0x12;
            }
            else if (keyCode == "ALT_PAUSE")
            {
                return 0x13;
            }
            else if (keyCode == "ALT_CAPITAL")
            {
                return 0x14;
            }
            else if (keyCode == "ALT_ESCAPE")
            {
                return 0x1B;
            }
            else if (keyCode == "ALT_SPACE")
            {
                return 0x20;
            }
            else if (keyCode == "ALT_SELECT")
            {
                return 0x29;
            }
            else if (keyCode == "ALT_PRINT")
            {
                return 0x2A;
            }
            else if (keyCode == "ALT_EXECUTE")
            {
                return 0x2B;
            }
            else if (keyCode == "ALT_SNAPSHOT")
            {
                return 0x2C;
            }
            else if (keyCode == "ALT_INSERT")
            {
                return 0x2D;
            }
            else if (keyCode == "ALT_DELETE")
            {
                return 0x2E;
            }
            else if (keyCode == "ALT_HELP")
            {
                return 0x2F;
            }
            else if (keyCode == "ALT_LWIN")
            {
                return 0x5B;
            }
            else if (keyCode == "ALT_RWIN")
            {
                return 0x5C;
            }
            else if (keyCode == "ALT_APPS")
            {
                return 0x5D;
            }
            else if (keyCode == "ALT_SLEEP")
            {
                return 0x5F;
            }
            else if (keyCode == "ALT_SCROLL")
            {
                return 0x91;
            }
            else if (keyCode == "ALT_LSHIFT")
            {
                return 0xA0;
            }
            else if (keyCode == "ALT_RSHIFT")
            {
                return 0xA1;
            }
            else if (keyCode == "ALT_LCONTROL")
            {
                return 0xA2;
            }
            else if (keyCode == "ALT_RCONTROL")
            {
                return 0xA3;
            }
            else if (keyCode == "ALT_LMENU")
            {
                return 0xA4;
            }
            else if (keyCode == "ALT_RMENU")
            {
                return 0xA5;
            }
            else if (keyCode == "ALT_BROWSER_BACK")
            {
                return 0xA6;
            }
            else if (keyCode == "ALT_BROWSER_FORWARD")
            {
                return 0xA7;
            }
            else if (keyCode == "ALT_BROWSER_REFRESH")
            {
                return 0xA8;
            }
            else if (keyCode == "ALT_BROWSER_STOP")
            {
                return 0xA9;
            }
            else if (keyCode == "ALT_BROWSER_SEARCH")
            {
                return 0xAA;
            }
            else if (keyCode == "ALT_BROWSER_FAVORITES")
            {
                return 0xAB;
            }
            else if (keyCode == "ALT_BROWSER_HOME")
            {
                return 0xAC;
            }
            else if (keyCode == "ALT_VOLUME_MUTE")
            {
                return 0xAD;
            }
            else if (keyCode == "ALT_VOLUME_DOWN")
            {
                return 0xAE;
            }
            else if (keyCode == "ALT_VOLUME_UP")
            {
                return 0xAF;
            }
            else if (keyCode == "ALT_MEDIA_NEXT")
            {
                return 0xB0;
            }
            else if (keyCode == "ALT_MEDIA_PREV")
            {
                return 0xB1;
            }
            else if (keyCode == "ALT_MEDIA_STOP")
            {
                return 0xB2;
            }
            else if (keyCode == "ALT_MEDIA_PLAY")
            {
                return 0xB3;
            }
            else if (keyCode == "ALT_MAIL")
            {
                return 0xB4;
            }
            else if (keyCode == "ALT_MEDIA_SELECT")
            {
                return 0xB5;
            }
            else if (keyCode == "ALT_APP1")
            {
                return 0xB6;
            }
            else if (keyCode == "ALT_APP2")
            {
                return 0xB7;
            }
            //Special keys
            else if (keyCode == "SPEC_KANA")
            {
                return 0x15;
            }
            else if (keyCode == "SPEC_JUNJA")
            {
                return 0x17;
            }
            else if (keyCode == "SPEC_FINAL")
            {
                return 0x18;
            }
            else if (keyCode == "SPEC_HANJA")
            {
                return 0x19;
            }
            else if (keyCode == "SPEC_CONVERT")
            {
                return 0x1C;
            }
            else if (keyCode == "SPEC_NONCOVERT")
            {
                return 0x1D;
            }
            else if (keyCode == "SPEC_ACCEPT")
            {
                return 0x1E;
            }
            else if (keyCode == "SPEC_MODECHANGE")
            {
                return 0x1F;
            }
            else if (keyCode == "SPEC_OEM1")
            {
                return 0xBA;
            }
            else if (keyCode == "SPEC_OEM_PLUS")
            {
                return 0xBB;
            }
            else if (keyCode == "SPEC_COMMA")
            {
                return 0xBC;
            }
            else if (keyCode == "SPEC_MINUS")
            {
                return 0xBD;
            }
            else if (keyCode == "SPEC_PERIOD")
            {
                return 0xBE;
            }
            else if (keyCode == "SPEC_OEM2")
            {
                return 0xBF;
            }
            else if (keyCode == "SPEC_OEM3")
            {
                return 0xC0;
            }
            else if (keyCode == "SPEC_OEM4")
            {
                return 0xDB;
            }
            else if (keyCode == "SPEC_OEM5")
            {
                return 0xDC;
            }
            else if (keyCode == "SPEC_OEM7")
            {
                return 0xDE;
            }
            else if (keyCode == "SPEC_OEM8")
            {
                return 0xDF;
            }
            else if (keyCode == "SPEC_OEM9")
            {
                return 0xE1;
            }
            else if (keyCode == "SPEC_OEM102")
            {
                return 0xE2;
            }
            else if (keyCode == "SPEC_PROCESSKEY")
            {
                return 0xE5;
            }
            else if (keyCode == "SPEC_PACKET")
            {
                return 0xE7;
            }
            else if (keyCode == "SPEC_ATTN")
            {
                return 0xF6;
            }
            else if (keyCode == "SPEC_CRSEL")
            {
                return 0xF7;
            }
            else if (keyCode == "SPEC_EXSEL")
            {
                return 0xF8;
            }
            else if (keyCode == "SPEC_EREOF")
            {
                return 0xF9;
            }
            else if (keyCode == "SPEC_NONAME")
            {
                return 0xFC;
            }
            else if (keyCode == "SPEC_PA1")
            {
                return 0xFD;
            }
            else if (keyCode == "SPEC_OEM_CLEAR")
            {
                return 0xFE;
            }
            else if (keyCode == "SPEC_ZOOM")
            {
                return 0xFB;
            }
            else if (keyCode == "SPEC_PLAY")
            {
                return 0xFA;
            }
            //Undefined keys
            else if (keyCode == "UND1")
            {
                return 0x0E;
            }
            else if (keyCode == "UND2")
            {
                return 0x0F;
            }
            else if (keyCode == "UND3")
            {
                return 0x16;
            }
            else if (keyCode == "UND4")
            {
                return 0x1A;
            }
            else if (keyCode == "UND5")
            {
                return 0x3A;
            }
            else if (keyCode == "UND6")
            {
                return 0x3B;
            }
            else if (keyCode == "UND7")
            {
                return 0x3C;
            }
            else if (keyCode == "UND8")
            {
                return 0x3D;
            }
            else if (keyCode == "UND9")
            {
                return 0x3E;
            }
            else if (keyCode == "UND10")
            {
                return 0x3F;
            }
            else if (keyCode == "UND11")
            {
                return 0x40;
            }

            return 0x00;
        }
    }
}