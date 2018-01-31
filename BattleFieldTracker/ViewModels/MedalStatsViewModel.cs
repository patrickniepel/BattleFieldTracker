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
    public class MedalStatsViewModel : BaseViewModel
    {
        #region Private Members

        private List<ResultMedalStats> _allMedals;
        private ObservableCollection<ResultMedalStats> _medals;
        private string _filterText;
        private bool _downloadFinished;

        #endregion

        #region Public Members

        public DelegateCommand ClearFilterCommand { [UsedImplicitly] get; [UsedImplicitly] set; }

        public string FilterText
        {
            get => _filterText;
            set
            {
                Set(ref _filterText, value);
                Filter();
            }
        }

        public ObservableCollection<ResultMedalStats> Medals
        {
            [UsedImplicitly]
            get => _medals;
            set => Set(ref _medals, value);
        }

        public bool DownloadFinished
        {
            [UsedImplicitly]
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        #endregion

        public MedalStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
        }

        public async Task DownloadMedalStats(string playerName)
        {
            var download = new DownloadMedalStats();
            RootObjectMedalStats root = await download.GetDownloadData(playerName);
            ApplyData(root);
        }

        private void ApplyData(RootObjectMedalStats root)
        {
            // If errors occured
            if (root == null)
            {
                return;
            }

            List<ResultMedalStats> medals = root.Result;
            _allMedals = medals;
            Medals = new ObservableCollection<ResultMedalStats>(_allMedals);

            // Download completed without errors
            DownloadFinished = true;
        }

        private void Filter()
        {
            Medals = string.IsNullOrWhiteSpace(FilterText)
                ? new ObservableCollection<ResultMedalStats>(_allMedals)
                : new ObservableCollection<ResultMedalStats>(_allMedals.Where(r => r.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                                                                       r.Awards.Any(a => a.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0)));
        }

        private void ClearFilterCommandExecute(object obj)
        {
            FilterText = "";
        }
    }
}
