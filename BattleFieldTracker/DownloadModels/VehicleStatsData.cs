using System;
using System.Collections.Generic;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{

    [UsedImplicitly]
    public class ValuesVehicleStats
    {
        public double Seconds { get; set; }
        public float Kills { get; set; }
        public float Destroyed { get; set; }
    }

    [UsedImplicitly]
    public class StatsVehicleStats
    {
        public ValuesVehicleStats Values { get; set; }
    }

    public class VehicleVehicleStats : IComparable<VehicleVehicleStats>
    {
        public StatsVehicleStats Stats { get; set; }
        public string Name { get; set; }       

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

        public int CompareTo(VehicleVehicleStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class ResultVehicleStats : IComparable<ResultVehicleStats>
    {
        public string Name { get; set; }
        public List<VehicleVehicleStats> Vehicles { get; set; }
        public int CompareTo(ResultVehicleStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class RootObjectVehicleStats
    {
        public List<ResultVehicleStats> Result { get; [UsedImplicitly] set; }
    }
}
