using System;
using System.Collections.Generic;
using BattleFieldTracker.Annotations;
using BattleFieldTracker.Helper;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// Models for the medal stats
    /// </summary>

    [UsedImplicitly]
    public class ProgressionMedalStats
    {
        private bool _unlocked;

        [UsedImplicitly]
        public bool Unlocked
        {
            get => _unlocked;
            set
            {
                _unlocked = value;
                UnlockedString = new BooleanToStringConverter().ConvertToString(_unlocked);
            }
        }

        public string UnlockedString { get; set; }
    }

    public class AwardMedalStats : IComparable<AwardMedalStats>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public ProgressionMedalStats Progression { get; set; }
        private string _imageUrl;

        [UsedImplicitly]
        public string ImageUrl
        {
            get => _imageUrl;
            set => _imageUrl = new ImageUrlGenerator().SetCorrectImageUrl(value);
        }

        public int CompareTo(AwardMedalStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class ResultMedalStats : IComparable<ResultMedalStats>
    {
        public List<AwardMedalStats> Awards { get; set; }
        public string Name { get; set; }
        public int CompareTo(ResultMedalStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class RootObjectMedalStats
    {
        public List<ResultMedalStats> Result { get; [UsedImplicitly] set; }
    }
}
