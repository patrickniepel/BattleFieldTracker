using System;
using System.Collections.Generic;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// (View)Models for the detail stats (Json representation). Will be filled with data when the download gets converted into json
    /// </summary>

    [UsedImplicitly]
    public class GameModeStatDetailStats
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public float Losses { get; set; }
        public float Wins { get; set; }

        private double _winLossRatio;

        public double WinLossRatio
        {
            get => _winLossRatio;
            set => _winLossRatio = Math.Round(value, 2);
        }
    }

    [UsedImplicitly]
    public class KitStatDetailStats
    {
        public float Kills { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public string TimeSpentString { get; set; }

        private double _secondsAs;

        [UsedImplicitly]
        public double SecondsAs
        {
            get => _secondsAs;
            set
            {
                _secondsAs = value;
                TimeSpentString = new TimeSpentCalculator().GetTimeSpentString(_secondsAs);
            }
        }
    }

    [UsedImplicitly]
    public class VehicleStatDetailStats
    {
        public float KillsAs { get; set; }
        public string Name { get; set; }
        public string TimeSpentString { get; set; }
        private double _timeSpent;

        [UsedImplicitly]
        public double TimeSpent
        {
            get => _timeSpent;
            set
            {
                _timeSpent = value;
                TimeSpentString = new TimeSpentCalculator().GetTimeSpentString(_timeSpent);
            }
        }
        public float VehiclesDestroyed { get; set; }
    }

    public class ResultDetailStats
    {
        public double AccuracyRatio { get; [UsedImplicitly] set; }
        public float AvengerKills { get; [UsedImplicitly] set; }
        public double AwardScore { get; [UsedImplicitly] set; }
        public int DogtagsTaken { get; [UsedImplicitly] set; }
        public int FlagsCaptured { get; [UsedImplicitly] set; }
        public int FlagsDefended { get; [UsedImplicitly] set; }
        public List<GameModeStatDetailStats> GameModeStats { get; [UsedImplicitly] set; }
        public int HeadShots { get; [UsedImplicitly] set; }
        public float Heals { get; [UsedImplicitly] set; }
        public int HighestKillStreak { get; set; }
        public double Kdr { get; [UsedImplicitly] set; }
        public float KillAssists { get; [UsedImplicitly] set; }
        public List<KitStatDetailStats> KitStats { get; [UsedImplicitly] set; }
        public double LongestHeadShot { get; [UsedImplicitly] set; }
        public float NemesisKills { get; [UsedImplicitly] set; }
        public float NemesisKillStreak { get; [UsedImplicitly] set; }
        public float Repairs { get; [UsedImplicitly] set; }
        public float Revives { get; [UsedImplicitly] set; }
        public float RoundsPlayed { get; [UsedImplicitly] set; }
        public float SaviorKills { get; [UsedImplicitly] set; }
        public double SquadScore { get; [UsedImplicitly] set; }
        public float SuppressionAssist { get; [UsedImplicitly] set; }
        public List<VehicleStatDetailStats> VehicleStats { get; [UsedImplicitly] set; }
    }

    public class RootObjectDetailStats
    {
        public ResultDetailStats Result { get; [UsedImplicitly] set; }
    }
}
