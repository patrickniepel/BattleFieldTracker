using System.Dynamic;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    class PlayerStatsViewModel
    {
        private string _displayName
        {
            get => DisplayName;

        }

        public string DisplayName { get; set; }
        public string PlayerRankImage { get; set; }
        public int PlayerRank { get; set; }
        public float PlayerCurrentXp { get; set; }
        public float PlayerTotalXp { get; set; }
        public float PlayerKills { get; set; }
        public float PlayerDeaths { get; set; }
        public float PlayerWins { get; set; }
        public float PlayerLosses { get; set; }
        public int PlayerSpm { get; set; }
        public int PlayerKpm { get; set; }
        public double PlayerTimePlayed { get; set; }

        public void DownloadPlayerStats(string playerName)
        {
            var download = new DownloadPlayerStats();
            RootObjectPlayerStats root = download.GetDownloadData(playerName);
            ApplyData(root);
        }

        private void ApplyData(RootObjectPlayerStats root)
        {
            var stats = root.result.gameStats.tunguska;

            DisplayName = root.profile.displayName;
            PlayerRankImage = stats.rank.imageUrl;
            PlayerRank = stats.rank.number;
            PlayerCurrentXp = stats.rankProgress.current;
            PlayerTotalXp = stats.rankProgress.total;
            PlayerKills = stats.kills;
            PlayerDeaths = stats.deaths;
            PlayerWins = stats.wins;
            PlayerLosses = stats.losses;
            PlayerSpm = (int)stats.spm;
            PlayerKpm = (int)stats.kpm;
            PlayerTimePlayed = stats.timePlayed;
        }
    }
}
