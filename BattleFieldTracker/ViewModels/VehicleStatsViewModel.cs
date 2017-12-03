using System.Collections.Generic;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class VehicleStatsViewModel : BaseViewModel
    {
        private List<ResultVehicleStats> _vehicles;

        public List<ResultVehicleStats> Vehicles
        {
            get => _vehicles;
            set => Set(ref _vehicles, value);
        }

        public void DownloadVehicleStats(string playerName)
        {
            var download = new DownloadVehicleStats();
            RootObjectVehicleStats root = download.GetDownloadData(playerName);
            ApplyData(root);
        }

        private void ApplyData(RootObjectVehicleStats root)
        {
            var vehicles = root.Result;
            Vehicles = vehicles;
        }
    }
}
