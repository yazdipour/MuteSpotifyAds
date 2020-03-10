using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MuteSpotifyAds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProcessLookUp(Process.GetCurrentProcess().MainWindowHandle);
        }

        private static void ProcessLookUp(IntPtr windowHandle)
        {
            foreach (var p in Process.GetProcessesByName("Spotify"))
                if (p.MainWindowTitle == "Advertisement")
                    AudioControl.ToggleMute(windowHandle);
        }
    }

    internal static class AudioControl
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public static void ToggleMute(IntPtr handle) { SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_MUTE); }
    }
}
