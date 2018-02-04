using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Handles the download of the vehicles stats
    /// </summary>
    public class DownloadVehicleStats : BaseDownload
    {
        public DownloadVehicleStats()
        {
            ContentAddress = "Progression/GetVehicles?platform=3&displayName=";
        }

        /// <summary>
        /// Starts the download and returns the converted response
        /// </summary>
        /// <param name="playerName">Name of the user</param>
        /// <returns>Json converted download response</returns>
        public async Task<RootObjectVehicleStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            var root = Converter.ConvertVehicleStatsToJson(Response);

            return root;
        }

        /// <summary>
        /// Connects to api server and tries to get the data
        /// </summary>
        /// <param name="playerName">Name of the user</param>
        /// <returns></returns>
        private async Task DownloadData(string playerName)
        {
            using (var httpClient = new HttpClient { BaseAddress = BaseAddress })
            {
                httpClient.DefaultRequestHeaders.Add(HeaderName, HeaderContent);

                using (var response = await httpClient.GetAsync(ContentAddress + playerName + "&game=tunguska").ConfigureAwait(false))
                {

                    string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Response = responseData;
                }
            }
        }
    }
}
