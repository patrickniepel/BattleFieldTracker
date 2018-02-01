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
    public class WeaponStatsViewModel : BaseViewModel
    {
        #region Private Members

        private List<ResultWeaponStats> _allWeapons;
        private ObservableCollection<ResultWeaponStats> _weapons;
        private bool _downloadFinished;
        private string _filterText;

        #endregion

        #region Public Members

        public DelegateCommand ClearFilterCommand { [UsedImplicitly] get; [UsedImplicitly] set; }

        public string FilterText
        {
            [UsedImplicitly]
            get => _filterText;
            set
            {
                Set(ref _filterText, value);
                Filter();
            }
        }

        public ObservableCollection<ResultWeaponStats> Weapons
        {
            [UsedImplicitly]
            get => _weapons;
            set => Set(ref _weapons, value);
        }

        public bool DownloadFinished
        {
            [UsedImplicitly]
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        #endregion

        public WeaponStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);   
        }

        public async Task DownloadWeaponStats(string playerName)
        {
            var download = new DownloadWeaponStats();
            RootObjectWeaponStats root = await download.GetDownloadData(playerName);

            //If Errors occured
            if (root == null)
            {
                return;
            }

            ApplyData(root);
        }

        private void ApplyData(RootObjectWeaponStats root)
        {
            List<ResultWeaponStats> weapons = root.Result;
            _allWeapons = weapons;
            Weapons = new ObservableCollection<ResultWeaponStats>(_allWeapons);

            // Download completed without errors
            DownloadFinished = true;
        }

        private void Filter()
        {
            Weapons = string.IsNullOrWhiteSpace(FilterText)
                ? new ObservableCollection<ResultWeaponStats>(_allWeapons)
                : new ObservableCollection<ResultWeaponStats>(_allWeapons.Where(r => r.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0 || 
                r.Weapons.Any(w => w.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0)));        
        }

        private void ClearFilterCommandExecute(object obj)
        {
            FilterText = "";
        }
    }
}
