﻿using System;
using System.Collections.Generic;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// (View)Models for the medal stats (Json representation). Will be filled with data when the download gets converted into json
    /// </summary>

    public class StagesProgressionMedalStats
    {
        public bool Unlocked { get; set; }
    }

    public class StagesMedalStats
    {
        public string Description { get; set; }
        public StagesProgressionMedalStats Progression { get; set; }
    }

    public class ProgressionMedalStats
    {
        private bool _unlocked;

        public bool Unlocked
        {
            get => _unlocked;
            set
            {
                _unlocked = value;
                RowOpacity = _unlocked ? 1 : 0.5;
            }
        }

        public double RowOpacity { get; set; }
    }

    public class AwardMedalStats : IComparable<AwardMedalStats>
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public ProgressionMedalStats Progression { get; set; }
        public List<StagesMedalStats> Stages { get; set; }
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
