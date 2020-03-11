using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MuteSpotifyAds
{
    internal class Program
    {
        private static bool _isMuted, _isAd;
        private static void Main(string[] args)
        {
            var t = new Timer(TimerCallback, null, 0, 1000);
            Console.WriteLine("Waiting for Ads (=_=)\n\nEnter to Stop...");
            Console.ReadLine();
        }

        private static void TimerCallback(object _)
        {
            _isAd = ProcessLookUp("Spotify", "Advertisement");
            if ((!_isMuted && _isAd) || (_isMuted && !_isAd))
            {
                _isMuted = !_isMuted;
                AudioControl.ToggleMute(Process.GetCurrentProcess().MainWindowHandle);
            }
        }

        private static bool ProcessLookUp(string processName, string triggerOn) 
            => Process.GetProcessesByName(processName).Any(p => p.MainWindowTitle == triggerOn);
    }
}
