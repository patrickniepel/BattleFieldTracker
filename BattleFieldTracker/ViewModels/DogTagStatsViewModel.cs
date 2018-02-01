using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BattleFieldTracker.Commands;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.ViewModels
{
    public class DogTagStatsViewModel : BaseViewModel
    {
        #region Private Members

        private List<ResultDogTagStats> _allDogTags;
        private ObservableCollection<ResultDogTagStats> _dogTags;
        private string _filterText;
        private bool _downloadFinished;

        #endregion

        #region Public Members

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

        #endregion

        public DogTagStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
        }

        public async Task DownloadDogTagStats(string playerName)
        {
            var download = new DownloadDogTagStats();
            RootObjectDogTagStats root = await download.GetDownloadData(playerName);

            //If Errors occured
            if (root == null)
            {
                return;
            }

            ApplyData(root);
        }

        private void ApplyData(RootObjectDogTagStats root)
        {
            List<ResultDogTagStats> dogTags = root.Result;
            _allDogTags = dogTags;
            DogTags = new ObservableCollection<ResultDogTagStats>(_allDogTags);

            // Download completed without errors
            DownloadFinished = true;
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
