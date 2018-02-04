using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Handles the download of the dogtags stats
    /// </summary>
    public class DownloadDogTagStats : BaseDownload
    {
        public DownloadDogTagStats()
        {
            ContentAddress = "Progression/GetDogtags?platform=3&displayName=";
        }

        /// <summary>
        /// Starts the download and returns the converted response
        /// </summary>
        /// <param name="playerName">Name of the user</param>
        /// <returns>Json converted download response</returns>
        public async Task<RootObjectDogTagStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            var root = Converter.ConvertDogTagStatsToJson(Response);

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

