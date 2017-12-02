using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTracker.DownloadModels
{
    public class ProgressionWeaponStats
    {
        public bool Unlocked { get; set; }
        public float ValueAcquired { get; set; }
        public float ValueNeeded { get; set; }
    }

    public class ValuesWeaponStats
    {
        public int Kills { get; set; }
        public int Headshots { get; set; }
        public double Accuracy { get; set; }
        public double Seconds { get; set; }
        public int Hits { get; set; }
        public int Shots { get; set; }
        public int? Destroyed { get; set; }
    }

    public class StatsWeaponStats
    {
        public Values Values { get; set; }
    }

    public class HiresWeaponStats
    {
        public string Png256XAny { get; set; }
        public string Png300XAny { get; set; }
        public string Png1024XAny { get; set; }
        public string Small { get; set; }
    }

    public class ImagesWeaponStats
    {
        public string Png256XAny { get; set; }
        public string Small { get; set; }
    }

    public class InfoWeaponStats
    {
        public string Ammo { get; set; }
        public string AmmoType { get; set; }
        public string RateOfFire { get; set; }
        public string Range { get; set; }
        public bool FireModeSingle { get; set; }
        public bool FireModeBurst { get; set; }
        public bool FireModeAuto { get; set; }
        public double StatDamage { get; set; }
        public double StatAccuracy { get; set; }
        public double StatMobility { get; set; }
        public float StatRange { get; set; }
        public double StatHandling { get; set; }
        public float StatReload { get; set; }
        public double StatControl { get; set; }
        public float StatFireRate { get; set; }
        public float StatAttackSpeed { get; set; }
        public bool CanBreakWood { get; set; }
        public bool CanCutBarbedWire { get; set; }
        public bool CanDamageLightVehicle { get; set; }
        public float NumberOfMagazines { get; set; }
        public List<object> DamageDropPoints { get; set; }
    }

    public class Progression2WeaponStats
    {
        public bool Unlocked { get; set; }
        public float ValueAcquired { get; set; }
        public float ValueNeeded { get; set; }
    }

    public class StarWeaponStats
    {
        public object Images { get; set; }
        public string ImageUrl { get; set; }
        public Progression2WeaponStats Progression { get; set; }
        public float TimesAquired { get; set; }
    }

    public class WeaponWeaponStats
    {
        public ProgressionWeaponStats Progression { get; set; }
        public Stats Stats { get; set; }
        public List<object> Accessories { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
        public HiresWeaponStats Hires { get; set; }
        public ImagesWeaponStats Images { get; set; }
        public string ImageUrl { get; set; }
        public InfoWeaponStats Info { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public StarWeaponStats Star { get; set; }
        public object Criterias { get; set; }
    }

    public class ResultWeaponStats
    {
        public string Name { get; set; }
        public List<WeaponWeaponStats> Weapons { get; set; }
    }

    public class ProfileWeaponStats
    {
        public string TrackerUrl { get; set; }
        public string DisplayName { get; set; }
        public int PersonaId { get; set; }
        public int Platform { get; set; }
    }

    public class RootObjectWeaponStats
    {
        public bool Successful { get; set; }
        public List<ResultWeaponStats> Result { get; set; }
        public ProfileWeaponStats Profile { get; set; }
        public string BbPrefix { get; set; }
    }
}
