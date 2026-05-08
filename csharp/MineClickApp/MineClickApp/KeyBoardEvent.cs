using System.Runtime.InteropServices;

namespace MineClickApp;

public class KeyBoardEvent
{

    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

    // https://stackoverflow.com/questions/1645815/how-can-i-programmatically-generate-keypress-events-in-c
    const int VK_UP = 0x26; //up key
    const int VK_DOWN = 0x28;  //down key
    const int VK_SPACE = 0x20;
    const int VK_LEFT = 0x25;
    const int VK_RIGHT = 0x27;
    const uint KEYEVENTF_KEYUP = 0x0002;
    const uint KEYEVENTF_EXTENDEDKEY = 0x0001;


    // https://ru.wikipedia.org/wiki/%D0%A1%D0%BA%D0%B0%D0%BD-%D0%BA%D0%BE%D0%B4

    public int Press()
    {
        while (true)
        {
            Thread.Sleep(5000);
            const int scan = 0x39;
            keybd_event(VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }

        return 0;
    }
}