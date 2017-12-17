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
        //private ObservableCollection<ResultWeaponStats> _weapons;
        //private string _filterText;
        private bool _downloadFinished;

        //public DelegateCommand ClearFilterCommand { get; set; }

        public List<ResultWeaponStats> AllWeapons
        {
            [UsedImplicitly] get => _allWeapons;
            set => Set(ref _allWeapons, value);
        }

//        public ObservableCollection<ResultWeaponStats> Weapons
//        {
//            [UsedImplicitly] get => _weapons;
//            set => Set(ref _weapons, value);
//        }
//
//        public string FilterText
//        {
//            get => _filterText;
//            set
//            {
//                Set(ref _filterText, value);
//                Filter();
//            }
//        }

        public bool DownloadFinished
        {
            [UsedImplicitly] get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public WeaponStatsViewModel()
        {
            //ClearFilterCommand = new DelegateCommand(ClearFilterCommandExecute);
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
            AllWeapons = weapons;
        }
//
//        private void Filter()
//        {
//            Weapons = string.IsNullOrWhiteSpace(FilterText)
//                ? new ObservableCollection<ResultWeaponStats>(_allWeapons)
//                : new ObservableCollection<ResultWeaponStats>(_allWeapons.Where(c =>
//                    c.Name?.IndexOf(FilterText, StringComparison.CurrentCultureIgnoreCase) >= 0));
//
//        }
//
//        private void ClearFilterCommandExecute(object obj)
//        {
//            FilterText = "";
//        }
//
//        public int CompareTo(ResultWeaponStats other)
//        {
//            return 
//        }
    }
}
