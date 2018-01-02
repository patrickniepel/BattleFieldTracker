using System.Collections.Generic;
using BattleFieldTracker.Annotations;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class DetailStatsViewModel : BaseViewModel
    {
        #region Private Members

        private bool _downloadFinished;

        private List<GameModeStatDetailStats> _gameModeStats;
        private List<KitStatDetailStats> _kitStats;
        private List<VehicleStatDetailStats> _vehicleStats;

        private double _accuracyRatio;
        private float _avengerKills;
        private double _awardScore;
        private int _dogtagsTaken;
        private int _flagsCaptured;
        private int _flagsDefended;
        private int _headshots;
        private float _heals;
        private int _highestKillStreak;
        private double _kdr; //Kill-Death-Ratio
        private float _killAssists;
        private double _longestHeadshot;
        private float _nemesisKills;
        private float _nemesisKillStreak;
        private float _repairs;
        private float _revives;
        private float _roundsPlayed;
        private float _saviorKills;
        private double _squadScore;
        private float _suppressionAssists;

        #endregion

        #region Public Members

        public bool DownloadFinished
        {
            [UsedImplicitly] get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public List<GameModeStatDetailStats> GameModeStats
        {
            [UsedImplicitly]
            get => _gameModeStats;
            set => Set(ref _gameModeStats, value);
        }

        public List<KitStatDetailStats> KitStats
        {
            [UsedImplicitly]
            get => _kitStats;
            set => Set(ref _kitStats, value);
        }

        public List<VehicleStatDetailStats> VehicleStats
        {
            [UsedImplicitly]
            get => _vehicleStats;
            set => Set(ref _vehicleStats, value);
        }

        public double AccuracyRatio
        {
            [UsedImplicitly]
            get => _accuracyRatio;
            set => Set(ref _accuracyRatio, value);
        }

        public float AvengerKills
        {
            [UsedImplicitly]
            get => _avengerKills;
            set => Set(ref _avengerKills, value);
        }

        public double AwardScore
        {
            [UsedImplicitly]
            get => _awardScore;
            set => Set(ref _awardScore, value);
        }

        public int DogtagsTaken
        {
            [UsedImplicitly]
            get => _dogtagsTaken;
            set => Set(ref _dogtagsTaken, value);
        }

        public int FlagsCaptured
        {
            [UsedImplicitly]
            get => _flagsCaptured;
            set => Set(ref _flagsCaptured, value);
        }

        public int FlagsDefended
        {
            [UsedImplicitly]
            get => _flagsDefended;
            set => Set(ref _flagsDefended, value);
        }

        public int Headshots
        {
            [UsedImplicitly]
            get => _headshots;
            set => Set(ref _headshots, value);
        }

        public float Heals
        {
            [UsedImplicitly]
            get => _heals;
            set => Set(ref _heals, value);
        }

        public int HighestKillStreak
        {
            [UsedImplicitly]
            get => _highestKillStreak;
            set => Set(ref _highestKillStreak, value);
        }

        public double Kdr
        {
            [UsedImplicitly]
            get => _kdr;
            set => Set(ref _kdr, value);
        }

        public float KillAssists
        {
            [UsedImplicitly]
            get => _killAssists;
            set => Set(ref _killAssists, value);
        }

        public double LongestHeadshot
        {
            [UsedImplicitly]
            get => _longestHeadshot;
            set => Set(ref _longestHeadshot, value);
        }

        public float NemesisKills
        {
            [UsedImplicitly]
            get => _nemesisKills;
            set => Set(ref _nemesisKills, value);
        }

        public float NemesisKillStreak
        {
            [UsedImplicitly]
            get => _nemesisKillStreak;
            set => Set(ref _nemesisKillStreak, value);
        }

        public float Repairs
        {
            [UsedImplicitly]
            get => _repairs;
            set => Set(ref _repairs, value);
        }

        public float Revives
        {
            [UsedImplicitly]
            get => _revives;
            set => Set(ref _revives, value);
        }

        public float RoundsPlayed
        {
            [UsedImplicitly]
            get => _roundsPlayed;
            set => Set(ref _roundsPlayed, value);
        }

        public float SaviorKills
        {
            [UsedImplicitly]
            get => _saviorKills;
            set => Set(ref _saviorKills, value);
        }

        public double SquadScore
        {
            [UsedImplicitly]
            get => _squadScore;
            set => Set(ref _squadScore, value);
        }

        public float SuppressionAssists
        {
            [UsedImplicitly]
            get => _suppressionAssists;
            set => Set(ref _suppressionAssists, value);
        }

        #endregion


        public void DownloadDetailStats(string playerName)
        {
            var download = new DownloadDetailStats();
            RootObjectDetailStats root = download.GetDownloadData(playerName);
            ApplyData(root);
        }

        private void ApplyData(RootObjectDetailStats root)
        {
            //If Errors occured
            if (root == null)
            {
                return;
            }

            ResultDetailStats results = root.Result;

            AccuracyRatio = results.AccuracyRatio;
            AvengerKills = results.AvengerKills;
            AwardScore = results.AwardScore;
            DogtagsTaken = results.DogtagsTaken;
            FlagsCaptured = results.FlagsCaptured;
            FlagsDefended = results.FlagsDefended;
            GameModeStats = results.GameModeStats;
            Headshots = results.HeadShots;
            Heals = results.Heals;
            HighestKillStreak = results.HighestKillStreak;
            Kdr = results.Kdr;
            KillAssists = results.KillAssists;
            KitStats = results.KitStats;
            LongestHeadshot = results.LongestHeadShot;
            NemesisKills = results.NemesisKills;
            NemesisKillStreak = results.NemesisKillStreak;
            Repairs = results.Repairs;
            Revives = results.Revives;
            RoundsPlayed = results.RoundsPlayed;
            SaviorKills = results.SaviorKills;
            SquadScore = results.SquadScore;
            SuppressionAssists = results.SuppressionAssist;
            VehicleStats = results.VehicleStats;

            // Download completed without errors
            DownloadFinished = true;
        }
    }
}
