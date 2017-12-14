using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BattleFieldTracker.Commands;
using BattleFieldTracker.Download;

namespace BattleFieldTracker.ViewModels
{
    public class ViewModelContainer : BaseViewModelValidation
    {
        private PlayerStatsViewModel _playerStatsViewModel;
        private WeaponStatsViewModel _weaponStatsViewModel;
        private VehicleStatsViewModel _vehicleStatsViewModel;
        private DogTagStatsViewModel _dogTagStatsViewModel;
        private MedalStatsViewModel _medalStatsViewModel;
        private DetailStatsViewModel _detailStatsViewModel;

        private string _playerName;
        private bool _isDownloading;

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
        
        public DogTagStatsViewModel DogTagStatsViewModel
        {
            get => _dogTagStatsViewModel;
            set => Set(ref _dogTagStatsViewModel, value);
        }

        public MedalStatsViewModel MedalStatsViewModel
        {
            get => _medalStatsViewModel;
            set => Set(ref _medalStatsViewModel, value);
        }

        public DetailStatsViewModel DetailStatsViewModel
        {
            get => _detailStatsViewModel;
            set => Set(ref _detailStatsViewModel, value);
        }

        public string PlayerName
        {
            get => _playerName;
            set
            {
                Set(IsPlayerNameValid, ref _playerName, value);
                SearchCommand.RaiseCanExecuteChanged();
            } 
        }

        public bool IsDownloading
        {
            get => _isDownloading;
            set => Set(ref _isDownloading, value);
        }

        public DelegateCommand SearchCommand { get; set; }

        public ViewModelContainer()
        {
            PlayerStatsViewModel = new PlayerStatsViewModel();
            WeaponStatsViewModel = new WeaponStatsViewModel();
            VehicleStatsViewModel = new VehicleStatsViewModel();
            DogTagStatsViewModel = new DogTagStatsViewModel();
            MedalStatsViewModel = new MedalStatsViewModel();
            DetailStatsViewModel = new DetailStatsViewModel();
            
            SearchCommand = new DelegateCommand(SearchCommandExecute);

            DownloadCounter.SharedInstance.DownloadFinished += HideProgressBar;
        }

        private void SearchCommandExecute(object obj)
        {
            IsDownloading = true;
            StartDownload();
        }

        private async Task StartDownload()
        {
            await Task.Run(() => _playerStatsViewModel.DownloadPlayerStats(PlayerName));
            await Task.Run(() => _detailStatsViewModel.DownloadDetailStats(PlayerName));
            await Task.Run(() => _weaponStatsViewModel.DownloadWeaponStats(PlayerName));
            await Task.Run(() => _vehicleStatsViewModel.DownloadVehicleStats(PlayerName));
            await Task.Run(() => _dogTagStatsViewModel.DownloadDogTagStats(PlayerName));
            await Task.Run(() => _medalStatsViewModel.DownloadMedalStats(PlayerName));
        }

        private bool IsPlayerNameValid(string playerName, [CallerMemberName] string propertyName = null)
        {
            string error = "Es muss ein gültiger Name eingegeben werden.";
            return SetError(() => !string.IsNullOrWhiteSpace(playerName), propertyName, error);
        }

        private void HideProgressBar()
        {
            IsDownloading = false;
        }
    }
}
