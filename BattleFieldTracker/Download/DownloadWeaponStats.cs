using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Handles the download of the weapon stats
    /// </summary>
    public class DownloadWeaponStats : BaseDownload
    {
        public DownloadWeaponStats()
        {
            ContentAddress = "Progression/GetWeapons?platform=3&displayName=";
        }

        public async Task<RootObjectWeaponStats> GetDownloadData(string playerName)
        {
            await DownloadData(playerName);

            // Check for errors
            if (Validation.SharedInstance.IsError)
            {
                return null;
            }

            var root = Converter.ConvertWeaponStatsToJson(Response);

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
