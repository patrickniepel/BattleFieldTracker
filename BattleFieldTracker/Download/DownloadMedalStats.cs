using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    public class DownloadMedalStats : BaseDownload
    {
        public DownloadMedalStats()
        {
            ContentAddress = "Progression/GetMedals?platform=3&displayName=";

        }

        public RootObjectMedalStats GetDownloadData(string playerName)
        {
            DownloadData(playerName).Wait();
            DownloadCounter.SharedInstance.NumberOfStatsToDownload--;

            if (Validation.SharedInstance.IsError)
            {
                return null;
            }

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
