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
        public double spm { get; set; }
        public double skill { get; set; }
        public object soldierImageUrl { get; set; }
        public double kpm { get; set; }
        public float losses { get; set; }
        public double timePlayed { get; set; }
        public object rank { get; set; }
        public object rankProgress { get; set; }
    }

    public class GameModeStatDetailStats
    {
        public string name { get; set; }
        public string prettyName { get; set; }
        public double score { get; set; }
        public float losses { get; set; }
        public float wins { get; set; }
        public double winLossRatio { get; set; }
    }

    public class KitStatDetailStats
    {
        public float kills { get; set; }
        public string name { get; set; }
        public string prettyName { get; set; }
        public double score { get; set; }
        public double secondsAs { get; set; }
    }

    public class VehicleStatDetailStats
    {
        public float killsAs { get; set; }
        public string name { get; set; }
        public string prettyName { get; set; }
        public double timeSpent { get; set; }
        public float vehiclesDestroyed { get; set; }
    }

    public class ResultDetailStats
    {
        public double accuracyRatio { get; set; }
        public float avengerKills { get; set; }
        public double awardScore { get; set; }
        public BasicStatsDetailStats basicStats { get; set; }
        public double bonusScore { get; set; }
        public int dogtagsTaken { get; set; }
        public string favoriteClass { get; set; }
        public int flagsCaptured { get; set; }
        public int flagsDefended { get; set; }
        public List<GameModeStatDetailStats> gameModeStats { get; set; }
        public int headShots { get; set; }
        public float Heals { get; set; }
        public int highestKillStreak { get; set; }
        public double kdr { get; set; }
        public float killAssists { get; set; }
        public List<KitStatDetailStats> kitStats { get; set; }
        public double longestHeadShot { get; set; }
        public float nemesisKills { get; set; }
        public float nemesisKillStreak { get; set; }
        public float repairs { get; set; }
        public float revives { get; set; }
        public object roundHistory { get; set; }
        public float roundsPlayed { get; set; }
        public float saviorKills { get; set; }
        public double squadScore { get; set; }
        public float suppressionAssist { get; set; }
        public List<VehicleStatDetailStats> vehicleStats { get; set; }
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
