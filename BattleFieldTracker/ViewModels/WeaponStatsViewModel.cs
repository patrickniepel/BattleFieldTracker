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
        private List<WeaponWeaponStats>[] _weaponList;
        private List<ResultWeaponStats> _allWeapons;
        private ObservableCollection<ResultWeaponStats> _weapons;
        private string _filterText;
        private bool _downloadFinished;

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
            Console.Out.WriteLine("AllDonwonad");
            foreach (var a in _allWeapons)
            {
                Console.Out.WriteLine(a.Name);
            }
            FillWeaponList();
        }

        private void FillWeaponList()
        {
            _weaponList = new List<WeaponWeaponStats>[_allWeapons.Count - 1]; //-1 da letzter ein Eintrag in _allWeapons nicht benötigt wird
            var tmpAllWeapons = new List<ResultWeaponStats>(_allWeapons);
            for (int i = 0; i < _weaponList.Length; i++)
            {
                _weaponList[i] = tmpAllWeapons.First().Weapons;
                tmpAllWeapons.RemoveAt(tmpAllWeapons.IndexOf(tmpAllWeapons.First()));
            }
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
