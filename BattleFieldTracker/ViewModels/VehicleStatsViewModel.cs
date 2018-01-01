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
    public class VehicleStatsViewModel : BaseViewModel
    {
        private List<ResultVehicleStats> _allVehicles;
        private ObservableCollection<ResultVehicleStats> _vehicles;
        private bool _downloadFinished;
        private string _filterText;

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

        public VehicleStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
        }

        public void DownloadVehicleStats(string playerName)
        {
            var download = new DownloadVehicleStats();
            RootObjectVehicleStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectVehicleStats root)
        {
            // If errors occured
            if (root == null)
            {
                return;
            }

            List<ResultVehicleStats> vehicles = root.Result;
            _allVehicles = vehicles;
            Vehicles = new ObservableCollection<ResultVehicleStats>(_allVehicles);
        }

        private void Filter()
        {
            Vehicles = string.IsNullOrWhiteSpace(FilterText)
                ? new ObservableCollection<ResultVehicleStats>(_allVehicles)
                : new ObservableCollection<ResultVehicleStats>(_allVehicles.Where(r => r.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                                                                                     r.Vehicles.Any(v => v.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0)));
        }

        private void ClearFilterCommandExecute(object obj)
        {
            FilterText = "";
        }
    }
}
