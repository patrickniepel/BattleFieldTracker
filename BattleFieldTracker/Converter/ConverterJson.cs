using BattleFieldTracker.DownloadModels;
using Newtonsoft.Json;

namespace BattleFieldTracker.Converter
{
    public class ConverterJson
    {
        public RootObjectPlayerStats ConvertPlayerStatsToJson(string playerStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectPlayerStats>(playerStats);
            return root;
        }

        public RootObjectWeaponStats ConvertWeaponStatsToJson(string weaponStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectWeaponStats>(weaponStats);
            return root;
        }

        public RootObjectVehicleStats ConvertVehicleStatsToJson(string vehicleStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectVehicleStats>(vehicleStats);
            return root;
        }

        public RootObjectDogTagStats ConvertDogTagStatsToJson(string dogtagStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectDogTagStats>(dogtagStats);
            return root;
        }

        public RootObjectMedalStats ConvertMedalStatsToJson(string medalStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectMedalStats>(medalStats);
            return root;
        }
    }
}
