using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    class DownloadWeaponStats : BaseDownload
    {
        public DownloadWeaponStats()
        {
            ContentAddress = "Progression/GetWeapons?platform=3&displayName=";
        }

        public RootObjectWeaponStats GetDownloadData(string playerName)
        {
            DownloadData(playerName).Wait();
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
