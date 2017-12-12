using System;

namespace BattleFieldTracker.Download
{
    public class DownloadCounter
    {
        public static readonly DownloadCounter SharedInstance = new DownloadCounter();

        private const int TotalDownloads = 3;

        private int _numberOfStatsToDownload;

        public int NumberOfStatsToDownload
        {
            get => _numberOfStatsToDownload;
            set
            {
                _numberOfStatsToDownload--;
                if (_numberOfStatsToDownload != 0) return;
                DownloadFinished();
                _numberOfStatsToDownload = TotalDownloads;
            }
        }

        public Action DownloadFinished;

        private DownloadCounter()
        {
            _numberOfStatsToDownload = TotalDownloads;
        }

        
    }
}
