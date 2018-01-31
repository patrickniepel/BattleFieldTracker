using System;
using System.Collections.Generic;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// Models for the dogtag stats
    /// </summary>

    [UsedImplicitly]
    public class ProgressionDogTagStats
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

    public class DogtagDogTagStats : IComparable<DogtagDogTagStats>
    {
        private bool _equipped;
        [UsedImplicitly]
        public bool Equipped
        {
            get => _equipped;
            set
            {
                _equipped = value;
                EquippedString = new BooleanToStringConverter().ConvertToString(_equipped);
            }
        }
        public string EquippedString { get; set; }
        public string Name { get; set; }
        public ProgressionDogTagStats Progression { get; set; }
        public int TimesTaken { get; set; }
        private string _imageUrl;

        [UsedImplicitly]
        public string ImageUrl
        {
            get => _imageUrl;
            set => _imageUrl = new ImageUrlGenerator().SetCorrectImageUrl(value); 
        }

        public int CompareTo(DogtagDogTagStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class ResultDogTagStats : IComparable<ResultDogTagStats>
    {
        public List<DogtagDogTagStats> Dogtags { get; set; }
        public string Name { get; set; }

        public int CompareTo(ResultDogTagStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class RootObjectDogTagStats
    {
        public List<ResultDogTagStats> Result { get; [UsedImplicitly] set; }
    }
}
