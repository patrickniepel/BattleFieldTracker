using System.Threading.Tasks;
using BattleFieldTracker.Annotations;
using BattleFieldTracker.Commands;
using BattleFieldTracker.Download;

namespace BattleFieldTracker.ViewModels
{
    /// <summary>
    /// Container for all viewmodels that holds data context
    /// </summary>
    public class ViewModelContainer : BaseViewModel
    {
        #region Private Members

        private PlayerStatsViewModel _playerStatsViewModel;
        private WeaponStatsViewModel _weaponStatsViewModel;
        private VehicleStatsViewModel _vehicleStatsViewModel;
        private DogTagStatsViewModel _dogTagStatsViewModel;
        private MedalStatsViewModel _medalStatsViewModel;
        private DetailStatsViewModel _detailStatsViewModel;

        private string _playerName;
        private bool _isDownloading;

        #endregion

        #region Public Members

        public PlayerStatsViewModel PlayerStatsViewModel
        {
            [UsedImplicitly]
            get => _playerStatsViewModel;
            set => Set(ref _playerStatsViewModel, value);
        }

        public WeaponStatsViewModel WeaponStatsViewModel
        {
            [UsedImplicitly]
            get => _weaponStatsViewModel;
            set => Set(ref _weaponStatsViewModel, value);
        }

        public VehicleStatsViewModel VehicleStatsViewModel
        {
            [UsedImplicitly]
            get => _vehicleStatsViewModel;
            set => Set(ref _vehicleStatsViewModel, value);
        }

        public DogTagStatsViewModel DogTagStatsViewModel
        {
            [UsedImplicitly]
            get => _dogTagStatsViewModel;
            set => Set(ref _dogTagStatsViewModel, value);
        }

        public MedalStatsViewModel MedalStatsViewModel
        {
            [UsedImplicitly]
            get => _medalStatsViewModel;
            set => Set(ref _medalStatsViewModel, value);
        }

        public DetailStatsViewModel DetailStatsViewModel
        {
            [UsedImplicitly]
            get => _detailStatsViewModel;
            set => Set(ref _detailStatsViewModel, value);
        }

        public string PlayerName
        {
            get => _playerName;
            [UsedImplicitly]
            set => Set(ref _playerName, value);
        }

        public bool IsDownloading
        {
            [UsedImplicitly]
            get => _isDownloading;
            set => Set(ref _isDownloading, value);
        }

        public DelegateCommand SearchCommand { [UsedImplicitly] get; [UsedImplicitly] set; }

        #endregion

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

        private async void StartDownload()
        {
            await Task.Run(() => _playerStatsViewModel.DownloadPlayerStats(PlayerName));
            await Task.Run(() => _detailStatsViewModel.DownloadDetailStats(PlayerName));
            await Task.Run(() => _weaponStatsViewModel.DownloadWeaponStats(PlayerName));
            await Task.Run(() => _vehicleStatsViewModel.DownloadVehicleStats(PlayerName));
            await Task.Run(() => _dogTagStatsViewModel.DownloadDogTagStats(PlayerName));
            await Task.Run(() => _medalStatsViewModel.DownloadMedalStats(PlayerName));
        }

        private void HideProgressBar()
        {
            IsDownloading = false;
        }
    }
}
