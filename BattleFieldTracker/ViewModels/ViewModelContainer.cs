
using System.Runtime.CompilerServices;
using BattleFieldTracker.Commands;

namespace BattleFieldTracker.ViewModels
{
    class ViewModelContainer : BaseViewModelValidation
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
            set => Set(IsPlayerNameValid, ref _playerName, value);
        }

        public DelegateCommand SearchCommand { get; set; }

        public ViewModelContainer()
        {
            PlayerStatsViewModel = new PlayerStatsViewModel();
            WeaponStatsViewModel = new WeaponStatsViewModel();
            VehicleStatsViewModel = new VehicleStatsViewModel();
            
            SearchCommand = new DelegateCommand(SearchCommandExecute);
        }

        private void SearchCommandExecute(object obj)
        {
            StartDownload();
        }

        public void StartDownload()
        {
            _playerStatsViewModel.DownloadPlayerStats(PlayerName);
            _weaponStatsViewModel.DownloadWeaponStats(PlayerName);
            //PlayerVehiclesViewModel.DownloadVehicleStats(Name);
        }

        private bool IsPlayerNameValid(string playerName, [CallerMemberName] string propertyName = null)
        {
            string error = "Es muss ein gültiger Name eingegeben werden.";
            return SetError(() => !string.IsNullOrWhiteSpace(playerName), propertyName, error);
        }
    }
}
