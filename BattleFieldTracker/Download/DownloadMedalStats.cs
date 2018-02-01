using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Handles the download of the medal stats
    /// </summary>
    public class DownloadMedalStats : BaseDownload
    {
        public DownloadMedalStats()
        {
            ContentAddress = "Progression/GetMedals?platform=3&displayName=";

        }

        public async Task<RootObjectMedalStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            var root = Converter.ConvertMedalStatsToJson(Response);

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
