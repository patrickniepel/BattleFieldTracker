using System.Collections.Generic;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class WeaponStatsViewModel : BaseViewModel
    {
        private List<ResultWeaponStats> _weapons;
        private bool _downloadFinished;

        public List<ResultWeaponStats> Weapons
        {
            get => _weapons;
            set => Set(ref _weapons, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
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
            var weapons = root.Result;
            Weapons = weapons;
        }
    }
}
