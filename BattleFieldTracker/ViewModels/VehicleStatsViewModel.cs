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
    public class VehicleStatsViewModel : BaseViewModel
    {
        #region Private Members

        private List<ResultVehicleStats> _allVehicles;
        private ObservableCollection<ResultVehicleStats> _vehicles;
        private bool _downloadFinished;
        private string _filterText;

        #endregion

        #region Public Members

        public DelegateCommand ClearFilterCommand { [UsedImplicitly] get; [UsedImplicitly] set; }

        public ObservableCollection<ResultVehicleStats> Vehicles
        {
            [UsedImplicitly]
            get => _vehicles;
            set => Set(ref _vehicles, value);
        }

        public string FilterText
        {
            get => _filterText;
            set
            {
                Set(ref _filterText, value);
                Filter();
            }
        }

        public bool DownloadFinished
        {
            [UsedImplicitly]
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        #endregion

        public VehicleStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
        }

        /// <summary>
        /// Starts the download
        /// </summary>
        /// <param name="playerName">Name of the user</param>
        /// <returns></returns>
        public async Task DownloadVehicleStats(string playerName)
        {
            var download = new DownloadVehicleStats();
            RootObjectVehicleStats root = await download.GetDownloadData(playerName);

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
        private void AssignData(RootObjectVehicleStats root)
        {
            List<ResultVehicleStats> vehicles = root.Result;
            _allVehicles = vehicles;
            Vehicles = new ObservableCollection<ResultVehicleStats>(_allVehicles);

            // Download completed without errors, vehicles tab can be displayed
            DownloadFinished = true;
        }

        /// <summary>
        /// Filters the data accordingly to the users search query
        /// </summary>
        private void Filter()
        {
            Vehicles = string.IsNullOrWhiteSpace(FilterText)
                ? new ObservableCollection<ResultVehicleStats>(_allVehicles)
                : new ObservableCollection<ResultVehicleStats>(_allVehicles.Where(r => r.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                                                                     r.Vehicles.Any(v => v.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0)));
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
