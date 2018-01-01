using System;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Counts the finished downloads and informs view to show the layout
    /// </summary>
    public class DownloadCounter
    {
        public static readonly DownloadCounter SharedInstance = new DownloadCounter();

        private const int TotalDownloads = 6;

        private int _numberOfStatsToDownload;

        /// <summary>
        /// Decreases variable when a download has finished
        /// </summary>
        public int NumberOfStatsToDownload
        {
            get => _numberOfStatsToDownload;

            // ReSharper disable once ValueParameterNotUsed (not needed)
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
