using System;
using System.Collections.Generic;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// Models for the medal stats
    /// </summary>

    [UsedImplicitly]
    public class ProgressionMedalStats
    {
        public bool Unlocked { get; set; }
    }

    public class AwardMedalStats : IComparable<AwardMedalStats>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public ProgressionMedalStats Progression { get; set; }

        private const string BbPrefix = "https://eaassets-a.akamaihd.net/battlelog/battlebinary";
        public string CorrectImageUrl { get; set; }
        private string _imageUrl;
        [UsedImplicitly]
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                SetCorrectImageUrl();
            }
        }

        private void SetCorrectImageUrl()
        {
            //urls begin with '[BB_Prefix]'

            string correctUrl = BbPrefix + _imageUrl.Substring(11);

            CorrectImageUrl = correctUrl;
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
