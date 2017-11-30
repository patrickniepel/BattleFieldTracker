using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    class VehicleStatsViewModel : BaseViewModel
    {
        public void DownloadVehicleStats(string playerName)
        {
            var download = new DownloadVehicleStats();
            RootObjectVehicleStats root = download.GetDownloadData(playerName);
        }

        private void ApplyData(RootObjectVehicleStats root)
        {

        }
    }
}
