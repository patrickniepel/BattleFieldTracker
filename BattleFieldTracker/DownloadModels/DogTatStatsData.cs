using System.Collections.Generic;

namespace BattleFieldTracker.DownloadModels
{
    public class ImagesDogTagStats
    {
        public string Png160xANY { get; set; }
        public string Small { get; set; }
    }

    public class ProgressionDogTagStats
    {
        public bool Unlocked { get; set; }
        public double ValueAcquired { get; set; }
        public double ValueNeeded { get; set; }
    }

    public class TagTypeDogTagStats
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public double Value { get; set; }
    }

    public class DogtagDogTagStats
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public bool Equipped { get; set; }
        public ImagesDogTagStats Images { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public ProgressionDogTagStats Progression { get; set; }
        public TagTypeDogTagStats TagType { get; set; }
        public int TimesTaken { get; set; }
        public string UnlockId { get; set; }

        private const string BbPrefix = "https://eaassets-a.akamaihd.net/battlelog/battlebinary";
        public string CorrectImageUrl { get; set; }
        private string _imageUrl;
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
    }

    public class ResultDogTagStats
    {
        public List<DogtagDogTagStats> Dogtags { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }

    public class ProfileDogTagStats
    {
        public string TrackerUrl { get; set; }
        public string DisplayName { get; set; }
        public int PersonaId { get; set; }
        public int Platform { get; set; }
    }

    public class RootObjectDogTagStats
    {
        public bool Successful { get; set; }
        public List<ResultDogTagStats> Result { get; set; }
        public Profile Profile { get; set; }
        public string BbPrefix { get; set; }
    }
}
