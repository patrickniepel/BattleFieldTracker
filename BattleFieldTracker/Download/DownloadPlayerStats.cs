using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BattleFieldTracker.Annotations;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.Download
{
    public class DownloadPlayerStats : BaseDownload
    {
        public DownloadPlayerStats()
        {
            ContentAddress = "Stats/CareerForOwnedGames?platform=3&displayName=";
        }

        public RootObjectPlayerStats GetDownloadData(string playerName)
        {
            DownloadData(playerName).Wait();
            DownloadCounter.SharedInstance.NumberOfStatsToDownload--;

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
                        Validation.SharedInstance.ValidateDownload(response);
                    
                        string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        Response = responseData;
                }
            }
        }
    }
}
