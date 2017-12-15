using System.Collections.Generic;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class VehicleStatsViewModel : BaseViewModel
    {
        private List<ResultVehicleStats> _vehicles;
        private bool _downloadFinished;

        public List<ResultVehicleStats> Vehicles
        {
            get => _vehicles;
            set => Set(ref _vehicles, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
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
            if (root == null)
            {
                return;
            }

            List<ResultVehicleStats> vehicles = root.Result;
            Vehicles = vehicles;
        }
    }
}
