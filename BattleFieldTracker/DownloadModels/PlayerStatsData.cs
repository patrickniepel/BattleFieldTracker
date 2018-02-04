using System.Collections.Generic;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// (View)Models for the player stats (Json representation). Will be filled with data when the download gets converted into json
    /// </summary>

    [UsedImplicitly]
    public class VehiclePlayerStats
    {
        public string Name { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class SidearmPlayerStats
    {
        public string Name { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class KitPlayerStats
    {
        public string KitId { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class PrimaryPlayerStats
    {
        public string Name { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class HighlightsByType
    {
        public List<VehiclePlayerStats> Vehicle { get; [UsedImplicitly] set; }
        public List<SidearmPlayerStats> Sidearm { get; [UsedImplicitly] set; }
        public List<KitPlayerStats> Kit { get; [UsedImplicitly] set; }
        public List<PrimaryPlayerStats> Primary { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class Rank
    {
        public string ImageUrl { get; [UsedImplicitly] set; }
        public string Name { get; [UsedImplicitly] set; }
        public int Number { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class RankProgress
    {
        public float Current { get; [UsedImplicitly] set; }
        public float Total { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class Tunguska
    {
        public HighlightsByType HighlightsByType { get; [UsedImplicitly] set; }
        public float Kills { get; [UsedImplicitly] set; }
        public float Wins { get; [UsedImplicitly] set; }
        public float Deaths { get; [UsedImplicitly] set; }
        public double Spm { get; [UsedImplicitly] set; }
        public double Kpm { get; [UsedImplicitly] set; }
        public float Losses { get; [UsedImplicitly] set; }
        public double TimePlayed { get; [UsedImplicitly] set; }
        public Rank Rank { get; [UsedImplicitly] set; }
        public RankProgress RankProgress { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class GameStats
    {
        public Tunguska Tunguska { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class Result
    {
        public GameStats GameStats { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class Profile
    {
        public string DisplayName { get; [UsedImplicitly] set; }
    }

    [UsedImplicitly]
    public class RootObjectPlayerStats
    {
        public Result Result { get; [UsedImplicitly] set; }
        public Profile Profile { get; [UsedImplicitly] set; }
    }
}
