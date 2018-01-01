using System.Collections.Generic;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// Models for the detail stats
    /// </summary>

    [UsedImplicitly]
    public class GameModeStatDetailStats
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public float Losses { get; set; }
        public float Wins { get; set; }
        public double WinLossRatio { get; set; }
    }

    [UsedImplicitly]
    public class KitStatDetailStats
    {
        public float Kills { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public double SecondsAs { get; set; }
    }

    [UsedImplicitly]
    public class VehicleStatDetailStats
    {
        public float KillsAs { get; set; }
        public string Name { get; set; }
        public double TimeSpent { get; set; }
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
        public int HighestKillStreak { get; [UsedImplicitly] set; }
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
