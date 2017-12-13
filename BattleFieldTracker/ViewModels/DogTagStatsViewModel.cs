using System.Collections.Generic;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class DogTagStatsViewModel : BaseViewModel
    {
        private List<ResultDogTagStats> _dogTags;
        private bool _downloadFinished;

        public List<ResultDogTagStats> DogTags
        {
            get => _dogTags;
            set => Set(ref _dogTags, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public void DownloadDogTagStats(string playerName)
        {
            var download = new DownloadDogTagStats();
            RootObjectDogTagStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectDogTagStats root)
        {
            if (root == null)
            {
                return;
            }

            var dogTags = root.Result;
            DogTags = dogTags;
        }
    }
}
