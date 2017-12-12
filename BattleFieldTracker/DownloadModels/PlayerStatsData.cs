using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    public class Progress
    {
        public float Current { get; set; }
        public float Total { get; set; }
    }

    public class Completion
    {
        public string Name { get; set; }
        public Progress Progress { get; set; }
        public object Rank { get; set; }
    }

    public class TagType
    {
        public int value { get; set; }
        public string name { get; set; }
        public string originalName { get; set; }
    }

    public class Images
    {
        public string Png160xANY { get; set; }
        public string Small { get; set; }
    }

    public class EquippedDogtag
    {
        public string name { get; set; }
        public string description { get; set; }
        public int index { get; set; }
        public string imageUrl { get; set; }
        public string unlockId { get; set; }
        public string category { get; set; }
        public object progression { get; set; }
        public bool equipped { get; set; }
        public TagType tagType { get; set; }
        public Images images { get; set; }
        public object expansions { get; set; }
        public float timesTaken { get; set; }
    }

    public class Progression
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public double accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
        public float? destroyed { get; set; }
    }

    public class Stats
    {
        public Values values { get; set; }
    }

    public class Progression2
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Star
    {
        public string imageUrl { get; set; }
        public float timesAquired { get; set; }
        public object images { get; set; }
        public Progression2 progression { get; set; }
    }

    public class KitRank
    {
        public string kitName { get; set; }
        public List<float> thresholds { get; set; }
        public float actualValue { get; set; }
        public float rank { get; set; }
    }

    public class HighlightDetails
    {
        public Progression progression { get; set; }
        public Stats stats { get; set; }
        public Star star { get; set; }
        public KitRank kitRank { get; set; }
    }

    public class Highlight
    {
        public object value { get; set; }
        public string HighlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails highlightDetails { get; set; }
        public string kitId { get; set; }
    }

    public class Progression3
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values2
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public double accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
    }

    public class Stats2
    {
        public Values2 values { get; set; }
    }

    public class Progression4
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Star2
    {
        public string imageUrl { get; set; }
        public float timesAquired { get; set; }
        public object images { get; set; }
        public Progression4 progression { get; set; }
    }

    public class HighlightDetails2
    {
        public Progression3 progression { get; set; }
        public Stats2 stats { get; set; }
        public Star2 star { get; set; }
        public object kitRank { get; set; }
    }

    public class Headshot
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails2 highlightDetails { get; set; }
    }

    public class Progression5
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values3
    {
        public double seconds { get; set; }
        public float kills { get; set; }
        public float destroyed { get; set; }
    }

    public class Stats3
    {
        public Values3 values { get; set; }
    }

    public class HighlightDetails3
    {
        public Progression5 progression { get; set; }
        public Stats3 stats { get; set; }
        public object star { get; set; }
        public object kitRank { get; set; }
    }

    public class Vehicle
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails3 highlightDetails { get; set; }
    }

    public class Progression6
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values4
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public float accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
    }

    public class Stats4
    {
        public Values4 values { get; set; }
    }

    public class HighlightDetails4
    {
        public Progression6 progression { get; set; }
        public Stats4 stats { get; set; }
        public object star { get; set; }
        public object kitRank { get; set; }
    }

    public class Accuracy
    {
        public float value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails4 highlightDetails { get; set; }
    }

    public class Progression7
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values5
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public double accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
        public float? destroyed { get; set; }
    }

    public class Stats5
    {
        public Values5 values { get; set; }
    }

    public class HighlightDetails5
    {
        public Progression7 progression { get; set; }
        public Stats5 stats { get; set; }
        public object star { get; set; }
        public object kitRank { get; set; }
    }

    public class Gadget
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails5 highlightDetails { get; set; }
    }

    public class Values6
    {
        public double seconds { get; set; }
        public float kills { get; set; }
        public float destroyed { get; set; }
    }

    public class Stats6
    {
        public Values6 values { get; set; }
    }

    public class HighlightDetails6
    {
        public object progression { get; set; }
        public Stats6 stats { get; set; }
        public object star { get; set; }
        public object kitRank { get; set; }
    }

    public class VehicleCategory
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails6 highlightDetails { get; set; }
    }

    public class Progression8
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values7
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public double accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
    }

    public class Stats7
    {
        public Values7 values { get; set; }
    }

    public class Progression9
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Star3
    {
        public string imageUrl { get; set; }
        public float timesAquired { get; set; }
        public object images { get; set; }
        public Progression9 progression { get; set; }
    }

    public class HighlightDetails7
    {
        public Progression8 progression { get; set; }
        public Stats7 stats { get; set; }
        public Star3 star { get; set; }
        public object kitRank { get; set; }
    }

    public class Weapon
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails7 highlightDetails { get; set; }
    }

    public class Progression10
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values8
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public double accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
    }

    public class Stats8
    {
        public Values8 values { get; set; }
    }

    public class HighlightDetails8
    {
        public Progression10 progression { get; set; }
        public Stats8 stats { get; set; }
        public object star { get; set; }
        public object kitRank { get; set; }
    }

    public class Sidearm
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails8 highlightDetails { get; set; }
    }

    public class KitRank2
    {
        public string kitName { get; set; }
        public List<float> thresholds { get; set; }
        public float actualValue { get; set; }
        public float rank { get; set; }
    }

    public class HighlightDetails9
    {
        public object progression { get; set; }
        public object stats { get; set; }
        public object star { get; set; }
        public KitRank2 kitRank { get; set; }
    }

    public class Kit
    {
        public float value { get; set; }
        public string kitId { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public object itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails9 highlightDetails { get; set; }
    }

    public class Progression11
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Values9
    {
        public float kills { get; set; }
        public float headshots { get; set; }
        public double accuracy { get; set; }
        public double seconds { get; set; }
        public float hits { get; set; }
        public float shots { get; set; }
    }

    public class Stats9
    {
        public Values9 values { get; set; }
    }

    public class Progression12
    {
        public float valueNeeded { get; set; }
        public float valueAcquired { get; set; }
        public bool unlocked { get; set; }
    }

    public class Star4
    {
        public string imageUrl { get; set; }
        public float timesAquired { get; set; }
        public object images { get; set; }
        public Progression12 progression { get; set; }
    }

    public class HighlightDetails10
    {
        public Progression11 progression { get; set; }
        public Stats9 stats { get; set; }
        public Star4 star { get; set; }
        public object kitRank { get; set; }
    }

    public class Primary
    {
        public string value { get; set; }
        public string highlightName { get; set; }
        public string highlightType { get; set; }
        public string itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string highlightText { get; set; }
        public HighlightDetails10 highlightDetails { get; set; }
    }

    public class HighlightsByType
    {
        public List<Headshot> headshots { get; set; }
        public List<Vehicle> vehicle { get; set; }
        public List<Accuracy> accuracy { get; set; }
        public List<Gadget> gadget { get; set; }
        public List<VehicleCategory> vehicleCategory { get; set; }
        public List<Weapon> weapon { get; set; }
        public List<Sidearm> sidearm { get; set; }
        public List<Kit> kit { get; set; }
        public List<Primary> primary { get; set; }
    }

    public class Rank
    {
        public string imageUrl { get; set; }
        public string name { get; set; }
        public int number { get; set; }
    }

    public class RankProgress
    {
        public float current { get; set; }
        public float total { get; set; }
    }

    public class Tunguska
    {
        public List<Completion> completion { get; set; }
        public List<EquippedDogtag> equippedDogtags { get; set; }
        public List<Highlight> highlights { get; set; }
        public HighlightsByType highlightsByType { get; set; }
        public float kills { get; set; }
        public float wins { get; set; }
        public float deaths { get; set; }
        public double spm { get; set; }
        public double skill { get; set; }
        public object soldierImageUrl { get; set; }
        public double kpm { get; set; }
        public float losses { get; set; }
        public double timePlayed { get; set; }
        public Rank rank { get; set; }
        public RankProgress rankProgress { get; set; }
    }

        public class TagType2
        {
            public float value { get; set; }
            public string name { get; set; }
            public string originalName { get; set; }
        }
    
        public class Images2
        {
            public string Png160xANY { get; set; }
            public string Small { get; set; }
        }
    
        public class EquippedDogtag2
        {
            public string name { get; set; }
            public string description { get; set; }
            public int index { get; set; }
            public string imageUrl { get; set; }
            public string unlockId { get; set; }
            public string category { get; set; }
            public object progression { get; set; }
            public bool equipped { get; set; }
            public TagType2 tagType { get; set; }
            public Images2 images { get; set; }
            public object expansions { get; set; }
            public int timesTaken { get; set; }
        }
    
        public class Rank2
        {
            public string imageUrl { get; set; }
            public string name { get; set; }
            public float number { get; set; }
        }
    
        public class RankProgress2
        {
            public float current { get; set; }
            public float total { get; set; }
        }
    
    //    public class Bf1cte
    //    {
    //        public List<object> completion { get; set; }
    //        public List<EquippedDogtag2> equippedDogtags { get; set; }
    //        public object highlights { get; set; }
    //        public object highlightsByType { get; set; }
    //        public float kills { get; set; }
    //        public float wins { get; set; }
    //        public float deaths { get; set; }
    //        public float spm { get; set; }
    //        public float skill { get; set; }
    //        public object soldierImageUrl { get; set; }
    //        public float kpm { get; set; }
    //        public float losses { get; set; }
    //        public double timePlayed { get; set; }
    //        public Rank2 rank { get; set; }
    //        public RankProgress2 rankProgress { get; set; }
    //    }

    [UsedImplicitly]
    public class GameStats
    {
        public Tunguska tunguska { get; set; }
        //public Bf1cte bf1cte { get; set; }
    }

    //    public class Rank3
    //    {
    //        public object imageUrl { get; set; }
    //        public string name { get; set; }
    //        public float number { get; set; }
    //    }
    //
    //    public class RankProgress3
    //    {
    //        public float current { get; set; }
    //        public float total { get; set; }
    //    }

    //    public class Stats10
    //    {
    //        public List<object> completion { get; set; }
    //        public object equippedDogtags { get; set; }
    //        public object highlights { get; set; }
    //        public object highlightsByType { get; set; }
    //        public float kills { get; set; }
    //        public float wins { get; set; }
    //        public float deaths { get; set; }
    //        public double spm { get; set; }
    //        public double skill { get; set; }
    //        public object soldierImageUrl { get; set; }
    //        public double kpm { get; set; }
    //        public float losses { get; set; }
    //        public double timePlayed { get; set; }
    //        public Rank3 rank { get; set; }
    //        public RankProgress3 rankProgress { get; set; }
    //    }

    public class Result
    {
        public List<object> highlights { get; set; }
        public object emblem { get; set; }
        public GameStats gameStats { get; set; }
        //public Stats10 stats { get; set; }
    }

    public class Profile
    {
        public string trackerUrl { get; set; }
        public string displayName { get; set; }
        public int personaId { get; set; }
        public int platform { get; set; }
    }

    public class RootObjectPlayerStats
    {
        public bool successful { get; set; }
        public Result result { get; set; }
        public Profile profile { get; set; }
        public string bbPrefix { get; set; }
    }
}
