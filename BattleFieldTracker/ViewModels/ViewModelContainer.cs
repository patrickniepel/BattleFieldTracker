
namespace BattleFieldTracker.ViewModels
{
    class ViewModelContainer : BaseViewModel
    {
        private PlayerStatsViewModel _playerStatsViewModel;
        private WeaponStatsViewModel _weaponStatsViewModel;
        private VehicleStatsViewModel _vehicleStatsViewModel;

        private string _playerName;

        public PlayerStatsViewModel PlayerStatsViewModel
        {
            get => _playerStatsViewModel;
            set => Set(ref _playerStatsViewModel, value);
        }

        public WeaponStatsViewModel WeaponStatsViewModel
        {
            get => _weaponStatsViewModel;
            set => Set(ref _weaponStatsViewModel, value);
        }

        public VehicleStatsViewModel VehicleStatsViewModel
        {
            get => _vehicleStatsViewModel;
            set => Set(ref _vehicleStatsViewModel, value);
        }

        public string PlayerName
        {
            get => _playerName;
            set => Set(ref _playerName, value);
        }

        public ViewModelContainer()
        {
            PlayerStatsViewModel = new PlayerStatsViewModel();
            WeaponStatsViewModel = new WeaponStatsViewModel();
            VehicleStatsViewModel = new VehicleStatsViewModel();
        }

        public void StartDownload()
        {
            _playerStatsViewModel.DownloadPlayerStats(PlayerName);
            //PlayerWeaponsViewModel.DownloadWeaponStats(Name);
            //PlayerVehiclesViewModel.DownloadVehicleStats(Name);
        }
    }
}
