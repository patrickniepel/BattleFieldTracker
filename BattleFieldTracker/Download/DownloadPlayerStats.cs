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
            //Check for Errors
            try
            {
                await DownloadData(playerName);
                if (!CheckForErrors())
                {
                    return null;
                }

                var root = Converter.ConvertPlayerStatsToJson(Response);

                return root;
            }
            // Failed Network Connection
            catch (HttpRequestException)
            {
                ShowErrorMessage("Überprüfe deine Internet-Verbindung");
                return null;
            }
        }

        private async Task DownloadData(string playerName)
        {
            using (var httpClient = new HttpClient { BaseAddress = BaseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HeaderName, HeaderContent);

                using (var response = await httpClient.GetAsync(ContentAddress + playerName).ConfigureAwait(false))
                {
                    string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    StatusCode = response.StatusCode;
                    Response = responseData;
                }
            }
        }
    }
}
