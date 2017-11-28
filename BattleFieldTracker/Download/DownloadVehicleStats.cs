using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    class DownloadVehicleStats : BaseDownload
    {
        public DownloadVehicleStats()
        {
            ContentAddress = "Progression/GetVehicles?platform=3&displayName=";

        }

        public RootObjectVehicleStats GetDownloadData(string playerName)
        {
            DownloadData(playerName).Wait();
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
