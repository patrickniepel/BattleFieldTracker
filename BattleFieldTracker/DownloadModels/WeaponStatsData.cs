using System;
using System.Collections.Generic;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    [UsedImplicitly]
    public class ValuesWeaponStats
    {
        public float Kills { get; set; }
        public double Seconds { get; set; }
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
            set => _price = value.Equals("-1") ? "Not Unlockable" : value;
        }

        public string CorrectImageUrl { get; set; }

        private const string BbPrefix = "https://eaassets-a.akamaihd.net/battlelog/battlebinary";

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
