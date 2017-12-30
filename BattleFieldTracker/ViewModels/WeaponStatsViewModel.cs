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
    public class WeaponStatsViewModel : BaseViewModel
    {
        private List<ResultWeaponStats> _allWeapons;
        private ObservableCollection<ResultWeaponStats> _weapons;
        private bool _downloadFinished;
        private string _filterText;

        public DelegateCommand ClearFilterCommand { [UsedImplicitly] get; set; }

        public string FilterText
        {
            [UsedImplicitly] get => _filterText;
            set
            {
                Set(ref _filterText, value);
                Filter();
            }
        }

        public ObservableCollection<ResultWeaponStats> Weapons
        {
            [UsedImplicitly] get => _weapons;
            set => Set(ref _weapons, value);
        }

        public bool DownloadFinished
        {
            [UsedImplicitly] get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public WeaponStatsViewModel()
        {
            ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);   
        }

        public void DownloadWeaponStats(string playerName)
        {
            var download = new DownloadWeaponStats();
            RootObjectWeaponStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectWeaponStats root)
        {
            if (root == null)
            {
                return;
            }
            List<ResultWeaponStats> weapons = root.Result;
            _allWeapons = weapons;
            Weapons = new ObservableCollection<ResultWeaponStats>(_allWeapons);
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
