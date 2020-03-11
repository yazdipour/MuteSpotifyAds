using System.Diagnostics;
using System.Linq;

namespace MuteSpotifyAds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if(ProcessLookUp("Spotify", "Advertisement"))
                AudioControl.ToggleMute(Process.GetCurrentProcess().MainWindowHandle);
        }

        private static bool ProcessLookUp(string processName, string triggerOn) 
            => Process.GetProcessesByName(processName).Any(p => p.MainWindowTitle == triggerOn);
    }
}
