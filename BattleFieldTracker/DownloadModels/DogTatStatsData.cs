using System;
using System.Collections.Generic;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    [UsedImplicitly]
    public class ProgressionDogTagStats
    {
        public bool Unlocked { get; set; }
        public double ValueAcquired { get; set; }
        public double ValueNeeded { get; set; }
    }

    public class DogtagDogTagStats : IComparable<DogtagDogTagStats>
    {
        //public string Category { get; set; }
        //public string Description { get; set; }
        public bool Equipped { get; set; }
        public string Name { get; set; }
        public ProgressionDogTagStats Progression { get; set; }
        public int TimesTaken { get; set; }

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
            var correctUrl = "";

            //urls begin with '[BB_Prefix]'

            correctUrl = BbPrefix + _imageUrl.Substring(11);

            CorrectImageUrl = correctUrl;
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
        //public bool Successful { get; set; }
        public List<ResultDogTagStats> Result { get; [UsedImplicitly] set; }
    }
}
