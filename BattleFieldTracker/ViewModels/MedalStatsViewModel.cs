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

        /// <summary>
        /// Starts the download
        /// </summary>
        /// <param name="playerName">Name of the user</param>
        /// <returns></returns>
        public async Task DownloadMedalStats(string playerName)
        {
            var download = new DownloadMedalStats();
            RootObjectMedalStats root = await download.GetDownloadData(playerName);

            //If Errors occured
            if (root == null)
            {
                return;
            }

            AssignData(root);
        }

        /// <summary>
        /// Assings all the downloaded data to the variables
        /// </summary>
        /// <param name="root">data as json</param>
        private void AssignData(RootObjectMedalStats root)
        {
            List<ResultMedalStats> medals = root.Result;
            _allMedals = medals;
            Medals = new ObservableCollection<ResultMedalStats>(_allMedals);

            // Download completed without errors, medals tab can be displayed
            DownloadFinished = true;
        }

        /// <summary>
        /// Filters the data accordingly to the users search query
        /// </summary>
        private void Filter()
        {
            Medals = string.IsNullOrWhiteSpace(FilterText)
                ? new ObservableCollection<ResultMedalStats>(_allMedals)
                : new ObservableCollection<ResultMedalStats>(_allMedals.Where(r => r.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                                                                       r.Awards.Any(a => a.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0)));
        }

        /// <summary>
        /// Clears the filter textbox
        /// </summary>
        /// <param name="obj"></param>
        private void ClearFilterCommandExecute(object obj)
        {
            FilterText = "";
        }
    }
}
