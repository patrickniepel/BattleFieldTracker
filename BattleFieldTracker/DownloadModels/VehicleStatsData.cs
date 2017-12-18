using System.Collections.Generic;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    [UsedImplicitly]
    public class ProgressionVehicleStats
    {
//        public bool Unlocked { get; set; }
//        public float ValueAcquired { get; set; }
//        public float ValueNeeded { get; set; }
    }

    [UsedImplicitly]
    public class ValuesVehicleStats
    {
//        public double Seconds { get; set; }
//        public float Kills { get; set; }
//        public float Destroyed { get; set; }
    }

    [UsedImplicitly]
    public class StatsVehicleStats
    {
        //public ValuesVehicleStats Values { get; set; }
    }

    public class VehicleVehicleStats
    {
//        public ProgressionVehicleStats Progression { get; set; }
//        public StatsVehicleStats Stats { get; set; }
//        public List<object> Accessories { get; set; }
//        public string Category { get; set; }
//        public string Description { get; set; }
//        public string Guid { get; set; }
//        public string Hires { get; set; }
//        public string Info { get; set; }
        public string Name { get; set; }
//        public string Price { get; set; }
//        public string Star { get; set; }
//        public object Criterias { get; set; }
        

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
    public class ResultVehicleStats
    {
        //public List<object> Accessories { get; set; }
        public string Name { get; set; }
        public List<VehicleVehicleStats> Vehicles { get; set; }
    }

    [UsedImplicitly]
    public class RootObjectVehicleStats
    {
        //public bool Successful { get; set; }
        public List<ResultVehicleStats> Result { get; [UsedImplicitly] set; }
    }
}
