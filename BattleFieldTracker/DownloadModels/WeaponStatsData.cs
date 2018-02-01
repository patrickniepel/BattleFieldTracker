using System;
using System.Collections.Generic;
using BattleFieldTracker.Helper;
using BattleFieldTracker.Properties;

namespace BattleFieldTracker.DownloadModels
{
    [UsedImplicitly]
    public class ValuesWeaponStats
    {
        public float Kills { get; set; }
        public string TimeSpentString { get; set; }

        private double _seconds;

        [UsedImplicitly]
        public double Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value;
                TimeSpentString = new TimeSpentCalculator().GetTimeSpentString(_seconds);
            }
        }
    }

    [UsedImplicitly]
    public class StatsWeaponStats
    {
        public ValuesWeaponStats Values { get; set; }
    }

    public class WeaponWeaponStats : IComparable<WeaponWeaponStats>
    {
        public StatsWeaponStats Stats { get; set; }
        public string Name { get; set; }

        private string _price;
        public string Price
        {
            get => _price;
            set => _price = value.Equals("-1") ? "Locked" : value;
        }
        private string _imageUrl;

        [UsedImplicitly]
        public string ImageUrl
        {
            get => _imageUrl;
            set => _imageUrl = new ImageUrlGenerator().SetCorrectImageUrl(value); 
        }

        public int CompareTo(WeaponWeaponStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class ResultWeaponStats : IComparable<ResultWeaponStats>
    {
        public string Name { get; set; }
        public List<WeaponWeaponStats> Weapons { get; set; }
        public int CompareTo(ResultWeaponStats other)
        {
            return String.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    [UsedImplicitly]
    public class RootObjectWeaponStats
    {
        public List<ResultWeaponStats> Result { get; [UsedImplicitly] set; }
    }
}
