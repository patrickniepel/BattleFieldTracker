
namespace BattleFieldTracker.ViewModels
{
    class ViewModelContainer
    {
        public PlayerStatsViewModel PlayerStatsViewModel;
        private WeaponStatsViewModel WeaponStatsViewModel;
        private VehicleStatsViewModel VehicleStatsViewModel;

        public string PlayerName { get; set; }

        private string Name => PlayerName;

        public ViewModelContainer()
        {
            PlayerStatsViewModel = new PlayerStatsViewModel();
            WeaponStatsViewModel = new WeaponStatsViewModel();
            VehicleStatsViewModel = new VehicleStatsViewModel();
        }

        public void StartDownload()
        {
            PlayerStatsViewModel.DownloadPlayerStats(Name);
            //PlayerWeaponsViewModel.DownloadWeaponStats(Name);
            //PlayerVehiclesViewModel.DownloadVehicleStats(Name);
        }
    }
}
