using System.Collections.Generic;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    class WeaponStatsViewModel : BaseViewModel
    {
        private List<ResultWeaponStats> _weapons;

        public List<ResultWeaponStats> Weapons
        {
            get => _weapons;
            set => Set(ref _weapons, value);
        }

        public void DownloadWeaponStats(string playerName)
        {
            var download = new DownloadWeaponStats();
            RootObjectWeaponStats root = download.GetDownloadData(playerName);
            ApplyData(root);
        }

        private void ApplyData(RootObjectWeaponStats root)
        {
            var weapons = root.Result;
            Weapons = weapons;
        }
    }
}
