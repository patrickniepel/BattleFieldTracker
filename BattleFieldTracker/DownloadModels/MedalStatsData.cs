using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{

    public class ProgressionMedalStats
    {
        public bool Unlocked { get; set; }
        //public double ValueAcquired { get; set; }
        //public double ValueNeeded { get; set; }
    }

    public class Progression2MedalStats
    {
        //public bool Unlocked { get; set; }
        //public double valueAcquired { get; set; }
        //public double ValueNeeded { get; set; }
    }

    public class CriteriaMedalStats
    {
        //public string Code { get; set; }
        //public string Name { get; set; }
        //public Progression2MedalStats Progression { get; set; }
    }

    public class Progression3MedalStats
    {
//        public bool Unlocked { get; set; }
//        public double ValueAcquired { get; set; }
//        public double ValueNeeded { get; set; }
    }

    public class StageMedalStats
    {
//        public string Code { get; set; }
//        public object CodexEntry { get; set; }
//        public List<CriteriaMedalStats> Criterias { get; set; }
//        public object Dependencies { get; set; }
//        public string Description { get; set; }
//        public List<object> Expansions { get; set; }
//        public string ImageUrl { get; set; }
//        public string Name { get; set; }
//        public Progression3MedalStats Progression { get; set; }
//        public object Stages { get; set; }
    }

    public class AwardMedalStats
    {
        //public string Code { get; set; }
        //public object CodexEntry { get; set; }
        //public List<CriteriaMedalStats> Criterias { get; set; }
        //public List<object> Dependencies { get; set; }
        public string Name { get; set; }
        public ProgressionMedalStats Progression { get; set; }
        //public List<StageMedalStats> Stages { get; set; }

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
    }

    [UsedImplicitly]
    public class ResultMedalStats
    {
        public List<AwardMedalStats> Awards { get; set; }
        public string Name { get; set; }
    }

    [UsedImplicitly]
    public class RootObjectMedalStats
    {
        //public bool Successful { get; set; }
        public List<ResultMedalStats> Result { get; [UsedImplicitly] set; }
    }
}
