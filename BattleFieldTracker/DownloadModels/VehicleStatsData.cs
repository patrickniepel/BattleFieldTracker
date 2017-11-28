using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTracker.DownloadModels
{
    public class ProgressionVehicleStats
    {
        public bool Unlocked { get; set; }
        public int ValueAcquired { get; set; }
        public int ValueNeeded { get; set; }
    }

    public class ValuesVehicleStats
    {
        public double Seconds { get; set; }
        public int Kills { get; set; }
        public int Destroyed { get; set; }
    }

    public class StatsVehicleStats
    {
        public ValuesVehicleStats Values { get; set; }
    }

    public class ImagesVehicleStats
    {
        public string Png256XAny { get; set; }
        public string Small { get; set; }
    }

    public class VehicleVehicleStats
    {
        public ProgressionVehicleStats Progression { get; set; }
        public StatsVehicleStats Stats { get; set; }
        public List<object> Accessories { get; set; }
        public object Category { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
        public object Hires { get; set; }
        public ImagesVehicleStats Images { get; set; }
        public string ImageUrl { get; set; }
        public object Info { get; set; }
        public string Name { get; set; }
        public object Price { get; set; }
        public object Star { get; set; }
        public object Criterias { get; set; }
    }

    public class ResultVehicleStats
    {
        public List<object> Accessories { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<VehicleVehicleStats> Vehicles { get; set; }
    }

    public class ProfileVehicleStats
    {
        public string TrackerUrl { get; set; }
        public string DisplayName { get; set; }
        public int PersonaId { get; set; }
        public int Platform { get; set; }
    }

    public class RootObjectVehicleStats
    {
        public bool Successful { get; set; }
        public List<ResultVehicleStats> Result { get; set; }
        public ProfileVehicleStats Profile { get; set; }
        public string BbPrefix { get; set; }
    }
}
