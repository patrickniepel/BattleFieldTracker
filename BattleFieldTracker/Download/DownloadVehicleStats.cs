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

        public async Task<RootObjectVehicleStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            var root = Converter.ConvertVehicleStatsToJson(Response);

            return root;
        }

        private async Task DownloadData(string playerName)
        {
            using (var httpClient = new HttpClient { BaseAddress = BaseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HeaderName, HeaderContent);

                using (var response = await httpClient.GetAsync(ContentAddress + playerName + "&game=tunguska").ConfigureAwait(false))
                {

                    string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Response = responseData;
                }
            }
        }
    }
}
