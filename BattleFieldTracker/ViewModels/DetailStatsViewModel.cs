using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class DetailStatsViewModel : BaseViewModel
    {
        private bool _downloadFinished;
        private float _heals;

        public float Heals
        {
            get => _heals;
            set => Set(ref _heals, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public void DownloadDetailStats(string playerName)
        {
            var download = new DownloadDetailStats();
            RootObjectDetailStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectDetailStats root)
        {
            if (root == null)
            {
                return;
            }

            var heals = root.Result.Heals;
            Heals = heals;
        }
    }
}
