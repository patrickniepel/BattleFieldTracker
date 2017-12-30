using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.Commands;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class MedalStatsViewModel : BaseViewModel
    {
        private List<ResultMedalStats> _allMedals;
        private ObservableCollection<ResultMedalStats> _medals;
        private string _filterText;
        private bool _downloadFinished;

        public DelegateCommand ClearFilterCommand { get; set; }

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
            get => _medals;
            set => Set(ref _medals, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public MedalStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
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
            _allMedals = medals;
            Medals = new ObservableCollection<ResultMedalStats>(_allMedals);
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
