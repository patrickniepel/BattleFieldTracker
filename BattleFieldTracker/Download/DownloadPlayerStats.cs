using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Handles the download of the player stats
    /// </summary>
    public class DownloadPlayerStats : BaseDownload
    {
        public DownloadPlayerStats()
        {
            ContentAddress = "Stats/CareerForOwnedGames?platform=3&displayName=";
        }

        public async Task<RootObjectPlayerStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            // Check for errors
            if (Validation.SharedInstance.IsError)
            {
                return null;
            }
            
            var root = Converter.ConvertPlayerStatsToJson(Response);

            return root;
        }

        private async Task DownloadData(string playerName)
        {
            using (var httpClient = new HttpClient { BaseAddress = BaseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HeaderName, HeaderContent);

                using (var response = await httpClient.GetAsync(ContentAddress + playerName).ConfigureAwait(false))
                {
                    // Validate the reponse from the server
                    Validation.SharedInstance.ValidateDownload(response);
                    
                    string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Response = responseData;
                }
            }
        }
    }
}
