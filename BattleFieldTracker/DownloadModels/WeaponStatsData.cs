using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.Annotations;

namespace BattleFieldTracker.DownloadModels
{
    public class ProgressionWeaponStats
    {
//        public bool Unlocked { get; set; }
//        public float ValueAcquired { get; set; }
//        public float ValueNeeded { get; set; }
    }

    [UsedImplicitly]
    public class ValuesWeaponStats
    {
        public float Kills { get; set; }
//        public float Headshots { get; set; }
//        public double Accuracy { get; set; }
        public double Seconds { get; set; }
//        public float Hits { get; set; }
//        public float Shots { get; set; }
//        public float Destroyed { get; set; }
    }

    [UsedImplicitly]
    public class StatsWeaponStats
    {
        public ValuesWeaponStats Values { get; set; }
    }

    public class InfoWeaponStats
    {
//        public string Ammo { get; set; }
//        public string AmmoType { get; set; }
//        public string RateOfFire { get; set; }
//        public string Range { get; set; }
//        public bool FireModeSingle { get; set; }
//        public bool FireModeBurst { get; set; }
//        public bool FireModeAuto { get; set; }
//        public double StatDamage { get; set; }
//        public double StatAccuracy { get; set; }
//        public double StatMobility { get; set; }
//        public float StatRange { get; set; }
//        public double StatHandling { get; set; }
//        public float StatReload { get; set; }
//        public double StatControl { get; set; }
//        public float StatFireRate { get; set; }
//        public float StatAttackSpeed { get; set; }
//        public bool CanBreakWood { get; set; }
//        public bool CanCutBarbedWire { get; set; }
//        public bool CanDamageLightVehicle { get; set; }
//        public float NumberOfMagazines { get; set; }
//        public List<object> DamageDropPoints { get; set; }
    }

    public class Progression2WeaponStats
    {
//        public bool Unlocked { get; set; }
//        public float ValueAcquired { get; set; }
//        public float ValueNeeded { get; set; }
    }

    public class StarWeaponStats
    {
//        public object Images { get; set; }
//        public string ImageUrl { get; set; }
//        public Progression2WeaponStats Progression { get; set; }
//        public float TimesAquired { get; set; }
    }

    public class WeaponWeaponStats
    {
//        public ProgressionWeaponStats Progression { get; set; }
        public StatsWeaponStats Stats { get; set; }
//        public List<object> Accessories { get; set; }
//        public string Category { get; set; }
//        public string Description { get; set; }
//        public string Guid { get; set; }
//        public InfoWeaponStats Info { get; set; }
        public string Name { get; set; }

        private string _price;
        public string Price
        {
            get => _price;
            set
            {
                if (value.Equals("-1"))
                {
                    _price = "Not Unlockable";
                }
            }
        }
//        public StarWeaponStats Star { get; set; }
//        public object Criterias { get; set; }
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
            var correctUrl = "";

            //urls begin with '[BB_Prefix]'

            correctUrl = BbPrefix + _imageUrl.Substring(11);

            CorrectImageUrl = correctUrl;
        }
    }

    [UsedImplicitly]
    public class ResultWeaponStats
    {
        public string Name { get; set; }
        public List<WeaponWeaponStats> Weapons { get; set; }
    }

    [UsedImplicitly]
    public class RootObjectWeaponStats
    {
        //public bool Successful { get; set; }
        public List<ResultWeaponStats> Result { get; [UsedImplicitly] set; }
    }
}
