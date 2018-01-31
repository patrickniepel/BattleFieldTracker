using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Handles the download of the detail stats
    /// </summary>
    public class DownloadDetailStats : BaseDownload
    {
        public DownloadDetailStats()
        {
            ContentAddress = "Stats/DetailedStats?platform=3&displayName=";
        }

        public async Task<RootObjectDetailStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            // check for errors
            if (Validation.SharedInstance.IsError)
            {
                return null;
            }

            var root = Converter.ConvertDetailStatsToJson(Response);

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
