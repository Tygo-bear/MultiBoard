#include <hidboot.h>
#include <usbhub.h>
#ifdef dobogusinclude
#endif
#include <SPI.h>

//=================================================================
//    CHANGE TO YOUR KEYBOATD ID!!!!
const String dynamicID = "7fba9a6d-61d1-4973-a68e-41a26309b48e";
//=================================================================

const byte numChars = 32;
char receivedChars[numChars];
bool serialLock = false;

class KbdRptParser : public KeyboardReportParser
{
    void PrintKey(uint8_t mod, uint8_t key);

  protected:
    void OnControlKeysChanged(uint8_t before, uint8_t after);

    void OnKeyDown	(uint8_t mod, uint8_t key);
    void OnKeyUp	(uint8_t mod, uint8_t key);
    void OnKeyPressed(uint8_t key);
};

void KbdRptParser::PrintKey(uint8_t m, uint8_t key)
{
  MODIFIERKEYS mod;
  *((uint8_t*)&mod) = m;

  Serial.print(" >");
  PrintHex<uint8_t>(key, 0x80);
  Serial.print("< \n");
};

void KbdRptParser::OnKeyDown(uint8_t mod, uint8_t key)
{
  Serial.print("DN ");
  PrintKey(mod, key);
  uint8_t c = OemToAscii(mod, key);

  if (c)
    OnKeyPressed(c);
}

void KbdRptParser::OnControlKeysChanged(uint8_t before, uint8_t after) 
{
  Serial.print(before);
  Serial.print( "_");
  Serial.print(after);
  Serial.print( "\n");

}

void KbdRptParser::OnKeyUp(uint8_t mod, uint8_t key)
{
  Serial.print("UP ");
  PrintKey(mod, key);
}

void KbdRptParser::OnKeyPressed(uint8_t key)
{

};


USB     Usb;
//USBHub     Hub(&Usb);
HIDBoot<USB_HID_PROTOCOL_KEYBOARD>    HidKeyboard(&Usb);

KbdRptParser Prs;

void setup()
{
  Serial.begin( 115200 );
  Serial.setTimeout(10);
  
#if !defined(__MIPSEL__)
#endif

  if (Usb.Init() == -1)
    Serial.println("ERROR:0001"); //OSC did not start.

  delay( 200 );

  HidKeyboard.SetReportParser(0, &Prs);
}

void serialEvent()
{
  if(serialLock)
  {
    
  }
  else
  {
    serialLock = true;
    int bufferStep = 0;
    while (Serial.available() > 0)
    {
      char rc = Serial.read();
      if(rc != '\n')
      {
        receivedChars[bufferStep] = rc;
        bufferStep++;
      }
      else
      {
        serialLock = false;
        Serial.println("close");
      }
    //static ID: 86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1
    
    }
    Serial.println(receivedChars);
    Serial.println("ID:&86ed8ce3-ee4c-4c27-b07d-cb563d7c3eb1&" + dynamicID);
  }
}

void loop()
{
  Usb.Task();
}
