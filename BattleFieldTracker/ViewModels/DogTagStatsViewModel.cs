using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BattleFieldTracker.Annotations;
using BattleFieldTracker.Commands;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class DogTagStatsViewModel : BaseViewModel
    {
        private List<ResultDogTagStats> _allDogTags;
        private ObservableCollection<ResultDogTagStats> _dogTags;
        private string _filterText;
        private bool _downloadFinished;

        public DelegateCommand ClearFilterCommand { get; [UsedImplicitly] set; }

        public string FilterText
        {
            get => _filterText;
            set
            {
                Set(ref _filterText, value);
                Filter();
            }
        }

        public ObservableCollection<ResultDogTagStats> DogTags
        {
            [UsedImplicitly]
            get => _dogTags;
            set => Set(ref _dogTags, value);
        }

        public bool DownloadFinished
        {
            [UsedImplicitly]
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public DogTagStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
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
            // If errors occured
            if (root == null)
            {
                return;
            }

            List<ResultDogTagStats> dogTags = root.Result;
            _allDogTags = dogTags;
            DogTags = new ObservableCollection<ResultDogTagStats>(_allDogTags);
        }

        private void Filter()
        {
            DogTags = string.IsNullOrWhiteSpace(FilterText)
                ? new ObservableCollection<ResultDogTagStats>(_allDogTags)
                : new ObservableCollection<ResultDogTagStats>(_allDogTags.Where(r => r.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                                                                       r.Dogtags.Any(d => d.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0)));
        }

        private void ClearFilterCommandExecute(object obj)
        {
            FilterText = "";
        }
    }
}
