using BattleFieldTracker.DownloadModels;
using Newtonsoft.Json;

namespace BattleFieldTracker.Converter
{
    /// <summary>
    /// Converts the given download string into json and returns the specified root object
    /// </summary>
    public class ConverterJson
    {   
        /// <summary>
        /// Converts the player stats to json
        /// </summary>
        /// <param name="playerStats">The downloaded string</param>
        /// <returns>Player stats as json</returns>
        public RootObjectPlayerStats ConvertPlayerStatsToJson(string playerStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectPlayerStats>(playerStats);
            return root;
        }

        /// <summary>
        /// Converts the weapon stats to json
        /// </summary>
        /// <param name="weaponStats">The downloaded string</param>
        /// <returns>Weapon stats as json</returns>
        public RootObjectWeaponStats ConvertWeaponStatsToJson(string weaponStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectWeaponStats>(weaponStats);
            return root;
        }

        /// <summary>
        /// Converts the vehicle stats to json
        /// </summary>
        /// <param name="vehicleStats">The downloaded string</param>
        /// <returns>vehicle stats as json</returns>
        public RootObjectVehicleStats ConvertVehicleStatsToJson(string vehicleStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectVehicleStats>(vehicleStats);
            return root;
        }

        /// <summary>
        /// Converts the dogtag stats to json
        /// </summary>
        /// <param name="dogtagStats">The downloaded string</param>
        /// <returns>dogtag stats as json</returns>
        public RootObjectDogTagStats ConvertDogTagStatsToJson(string dogtagStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectDogTagStats>(dogtagStats);
            return root;
        }

        /// <summary>
        /// Converts the medal stats to json
        /// </summary>
        /// <param name="medalStats">The downloaded string</param>
        /// <returns>medal stats as json</returns>
        public RootObjectMedalStats ConvertMedalStatsToJson(string medalStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectMedalStats>(medalStats);
            return root;
        }

        /// <summary>
        /// Converts the detail stats to json
        /// </summary>
        /// <param name="detailStats">The downloaded string</param>
        /// <returns>detail stats as json</returns>
        public RootObjectDetailStats ConvertDetailStatsToJson(string detailStats)
        {
            var root = JsonConvert.DeserializeObject<RootObjectDetailStats>(detailStats);
            return root;
        }
    }
}
