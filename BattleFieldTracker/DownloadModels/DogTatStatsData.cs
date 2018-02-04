using System;
using System.Collections.Generic;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// (View)Models for the dogtag stats (Json representation). Will be filled with data when the download gets converted into json
    /// </summary>

    [UsedImplicitly]
    public class ProgressionDogTagStats
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

    public class DogtagDogTagStats : IComparable<DogtagDogTagStats>
    {
        public bool Equipped { get; set; }
        public string Name { get; set; }
        public ProgressionDogTagStats Progression { get; set; }
        public int TimesTaken { get; set; }
        private string _imageUrl;
        public string Description { get; set; }

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
