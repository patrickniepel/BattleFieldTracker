using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTracker.DownloadModels
{
    public class BasicStatsDetailStats
    {
        public List<object> completion { get; set; }
        public object equippedDogtags { get; set; }
        public object highlights { get; set; }
        public object highlightsByType { get; set; }
        public float kills { get; set; }
        public float wins { get; set; }
        public float deaths { get; set; }
        public double Spm { get; set; }
        public double Skill { get; set; }
        public object SoldierImageUrl { get; set; }
        public double Kpm { get; set; }
        public float Losses { get; set; }
        public double TimePlayed { get; set; }
        public object Rank { get; set; }
        public object RankProgress { get; set; }
    }

    public class GameModeStatDetailStats
    {
        public string Name { get; set; }
        public string PrettyName { get; set; }
        public double Score { get; set; }
        public float Losses { get; set; }
        public float Wins { get; set; }
        public double WinLossRatio { get; set; }
    }

    public class KitStatDetailStats
    {
        public float Kills { get; set; }
        public string Name { get; set; }
        public string PrettyName { get; set; }
        public double Score { get; set; }
        public double SecondsAs { get; set; }
    }

    public class VehicleStatDetailStats
    {
        public float KillsAs { get; set; }
        public string Name { get; set; }
        public string PrettyName { get; set; }
        public double TimeSpent { get; set; }
        public float VehiclesDestroyed { get; set; }
    }

    public class ResultDetailStats
    {
        public double AccuracyRatio { get; set; }
        public float AvengerKills { get; set; }
        public double AwardScore { get; set; }
        public BasicStatsDetailStats BasicStats { get; set; }
        public double BonusScore { get; set; }
        public int DogtagsTaken { get; set; }
        public string FavoriteClass { get; set; }
        public int FlagsCaptured { get; set; }
        public int FlagsDefended { get; set; }
        public List<GameModeStatDetailStats> GameModeStats { get; set; }
        public int HeadShots { get; set; }
        public float Heals { get; set; }
        public int HighestKillStreak { get; set; }
        public double Kdr { get; set; }
        public float KillAssists { get; set; }
        public List<KitStatDetailStats> KitStats { get; set; }
        public double LongestHeadShot { get; set; }
        public float NemesisKills { get; set; }
        public float NemesisKillStreak { get; set; }
        public float Repairs { get; set; }
        public float Revives { get; set; }
        public object RoundHistory { get; set; }
        public float RoundsPlayed { get; set; }
        public float SaviorKills { get; set; }
        public double SquadScore { get; set; }
        public float SuppressionAssist { get; set; }
        public List<VehicleStatDetailStats> VehicleStats { get; set; }
    }

    public class ProfileDetailStats
    {
        public string TrackerUrl { get; set; }
        public string DisplayName { get; set; }
        public int PersonaId { get; set; }
        public int Platform { get; set; }
    }

    public class RootObjectDetailStats
    {
        public bool Successful { get; set; }
        public ResultDetailStats Result { get; set; }
        public ProfileDetailStats Profile { get; set; }
        public string BbPrefix { get; set; }
    }
}
