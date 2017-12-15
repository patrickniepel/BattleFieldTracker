using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private float _suppressionAssits;

        #endregion

        #region Public Members

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        public List<GameModeStatDetailStats> GameModeStats
        {
            get => _gameModeStats;
            set => Set(ref _gameModeStats, value);
        }

        public List<KitStatDetailStats> KitStats
        {
            get => _kitStats;
            set => Set(ref _kitStats, value);
        }

        public List<VehicleStatDetailStats> VehicleStats
        {
            get => _vehicleStats;
            set => Set(ref _vehicleStats, value);
        }

        public double AccuracyRatio
        {
            get => _accuracyRatio;
            set => Set(ref _accuracyRatio, value);
        }

        public float AvengerKills
        {
            get => _avengerKills;
            set => Set(ref _avengerKills, value);
        }

        public double AwardScore
        {
            get => _awardScore;
            set => Set(ref _awardScore, value);
        }

        public int DogtagsTaken
        {
            get => _dogtagsTaken;
            set => Set(ref _dogtagsTaken, value);
        }

        public int FlagsCaptured
        {
            get => _flagsCaptured;
            set => Set(ref _flagsCaptured, value);
        }

        public int FlagsDefended
        {
            get => _flagsDefended;
            set => Set(ref _flagsDefended, value);
        }

        public int Headshots
        {
            get => _headshots;
            set => Set(ref _headshots, value);
        }

        public float Heals
        {
            get => _heals;
            set => Set(ref _heals, value);
        }

        public int HighestKillStreak
        {
            get => _highestKillStreak;
            set => Set(ref _highestKillStreak, value);
        }

        public double Kdr
        {
            get => _kdr;
            set => Set(ref _kdr, value);
        }

        public float KillAssists
        {
            get => _killAssists;
            set => Set(ref _killAssists, value);
        }

        public double LongestHeadshot
        {
            get => _longestHeadshot;
            set => Set(ref _longestHeadshot, value);
        }

        public float NemesisKills
        {
            get => _nemesisKills;
            set => Set(ref _nemesisKills, value);
        }

        public float NemesisKillStreak
        {
            get => _nemesisKillStreak;
            set => Set(ref _nemesisKillStreak, value);
        }

        public float Repairs
        {
            get => _repairs;
            set => Set(ref _repairs, value);
        }

        public float Revives
        {
            get => _revives;
            set => Set(ref _revives, value);
        }

        public float RoundsPlayed
        {
            get => _roundsPlayed;
            set => Set(ref _roundsPlayed, value);
        }

        public float SaviorKills
        {
            get => _saviorKills;
            set => Set(ref _saviorKills, value);
        }

        public double SquadScore
        {
            get => _squadScore;
            set => Set(ref _squadScore, value);
        }

        public float SuppressionAssists
        {
            get => _suppressionAssits;
            set => Set(ref _suppressionAssits, value);
        }

        #endregion


        public void DownloadDetailStats(string playerName)
        {
            var download = new DownloadDetailStats();
            RootObjectDetailStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectDetailStats root)
        {
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
        }
    }
}
