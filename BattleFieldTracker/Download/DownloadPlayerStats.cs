﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            var root = Converter.ConvertPlayerStatsToJson(Response);

            if (Response.Equals("Bad Request") || Response.Equals("Internal Server Error"))
            {
                root.Message = "Ein Fehler ist aufgetreten!";
            }
            if (!root.successful)
            {
                root.Message = "Spieler kann nicht gefunden werden!";
            }
            
            return root;
        }

        private async Task DownloadData(string playerName)
        {
            using (var httpClient = new HttpClient { BaseAddress = BaseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HeaderName, HeaderContent);

                using (var response = await httpClient.GetAsync(ContentAddress + playerName).ConfigureAwait(false))
                {

                    string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Response = responseData;
                }
            }
        }
    }
}
