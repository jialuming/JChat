using System;
using System.Runtime.InteropServices;

namespace JStyleLib.Win32
{
    public class Motheds
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
}
