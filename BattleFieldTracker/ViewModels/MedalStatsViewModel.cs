using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class MedalStatsViewModel : BaseViewModel
    {
        private List<ResultMedalStats> _medals;
        private bool _downloadFinished;

        public List<ResultMedalStats> Medals
        {
            get => _medals;
            set => Set(ref _medals, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public void DownloadMedalStats(string playerName)
        {
            var download = new DownloadMedalStats();
            RootObjectMedalStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectMedalStats root)
        {
            if (root == null)
            {
                return;
            }

            List<ResultMedalStats> medals = root.Result;
            Medals = medals;
        }
    }
}
