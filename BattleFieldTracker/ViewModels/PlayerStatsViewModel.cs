﻿using System;
using System.Threading.Tasks;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.ViewModels
{
    public class PlayerStatsViewModel : BaseViewModel
    {
        #region Private Members

        private string _displayName;
        private string _rankImage;
        private string _rankName;
        private int _rank;
        private float _currentXp;
        private float _totalXp;
        private float _kills;
        private float _deaths;
        private float _wins;
        private float _losses;
        private int _spm;
        private int _kpm;
        private string _timePlayed;
        private string _topPrimary;
        private string _topSecondary;
        private string _topVehicle;
        private string _topClass;

        private bool _downloadFinished;

        #endregion

        #region Public Members

        public string DisplayName
        {
            [UsedImplicitly]
            get => _displayName;
            set => Set(ref _displayName, value);
        }

        public string RankImage
        {
            [UsedImplicitly]
            get => _rankImage;
            set => Set(ref _rankImage, value);
        }

        public string RankName
        {
            [UsedImplicitly]
            get => _rankName;
            set => Set(ref _rankName, value);
        }

        public int Rank
        {
            [UsedImplicitly]
            get => _rank;
            set => Set(ref _rank, value);
        }

        public float CurrentXp
        {
            [UsedImplicitly]
            get => _currentXp;
            set => Set(ref _currentXp, value);
        }

        public float TotalXp
        {
            [UsedImplicitly]
            get => _totalXp;
            set => Set(ref _totalXp, value);
        }

        public float Kills
        {
            [UsedImplicitly]
            get => _kills;
            set => Set(ref _kills, value);
        }

        public float Deaths
        {
            [UsedImplicitly]
            get => _deaths;
            set => Set(ref _deaths, value);
        }

        public float Wins
        {
            [UsedImplicitly]
            get => _wins;
            set => Set(ref _wins, value);
        }

        public float Losses
        {
            [UsedImplicitly]
            get => _losses;
            set => Set(ref _losses, value);
        }

        public int Spm
        {
            [UsedImplicitly]
            get => _spm;
            set => Set(ref _spm, value);
        }

        public int Kpm
        {
            [UsedImplicitly]
            get => _kpm;
            set => Set(ref _kpm, value);
        }

        public string TimePlayed
        {
            [UsedImplicitly]
            get => _timePlayed;
            set => Set(ref _timePlayed, value);
        }

        public string TopClass
        {
            [UsedImplicitly]
            get => _topClass;
            set => Set(ref _topClass, value);
        }

        public string TopVehicle
        {
            [UsedImplicitly]
            get => _topVehicle;
            set => Set(ref _topVehicle, value);
        }

        public string TopPrimary
        {
            [UsedImplicitly]
            get => _topPrimary;
            set => Set(ref _topPrimary, value);
        }

        public string TopSecondary
        {
            [UsedImplicitly]
            get => _topSecondary;
            set => Set(ref _topSecondary, value);
        }

        public bool DownloadFinished
        {
            [UsedImplicitly]
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        #endregion

        /// <summary>
        /// Starts the download
        /// </summary>
        /// <param name="playerName">Name of the user</param>
        /// <returns>True if no errors occured</returns>
        public async Task<bool> DownloadPlayerStats(string playerName)
        {
            var download = new DownloadPlayerStats();
            RootObjectPlayerStats root = await download.GetDownloadData(playerName);

            if (root == null)
            {
                return false;
            }
            AssignData(root);
            return true;
        }

        /// <summary>
        /// Assings all the downloaded data to the variables
        /// </summary>
        /// <param name="root">data as json</param>
        private void AssignData(RootObjectPlayerStats root)
        {
            var stats = root.Result.GameStats.Tunguska;
            
            DisplayName = root.Profile.DisplayName;
            RankImage = new ImageUrlGenerator().SetCorrectImageUrl(stats.Rank.ImageUrl);
            Rank = stats.Rank.Number;
            RankName = stats.Rank.Name;
            CurrentXp = stats.RankProgress.Current;
            TotalXp = stats.RankProgress.Total;
            Kills = stats.Kills;
            Deaths = stats.Deaths;
            Wins = stats.Wins;
            Losses = stats.Losses;
            Spm = (int)stats.Spm;
            Kpm = (int)stats.Kpm;
            TimePlayed = new TimeSpentCalculator().GetTimeSpentString(stats.TimePlayed);
            

            var highlights = stats.HighlightsByType;
            TopClass = highlights.Kit[0].KitId;
            TopVehicle = highlights.Vehicle[0].Name;
            TopPrimary = highlights.Primary[0].Name;
            TopSecondary = highlights.Sidearm[0].Name;

            // Download completed withour errors, player stats tab can be displayed
            DownloadFinished = true;
        }
    }
}
