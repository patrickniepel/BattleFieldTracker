using System;
using System.Collections.Generic;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    /// <summary>
    /// (View)Models for the vehicle stats (Json representation). Will be filled with data when the download gets converted into json
    /// </summary>

    [UsedImplicitly]
    public class ValuesVehicleStats
    {
        private double _seconds;
        public string TimeSpentString { get; set; }

        public double Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value;
                TimeSpentString = new TimeSpentCalculator().GetTimeSpentString(_seconds);
            }
        }
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
        private string _imageUrl;

        [UsedImplicitly]
        public string ImageUrl
        {
            get => _imageUrl;
            set => _imageUrl = new ImageUrlGenerator().SetCorrectImageUrl(value); 
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
