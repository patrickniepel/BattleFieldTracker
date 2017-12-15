using System.Windows;
using BattleFieldTracker.Download;
using BattleFieldTracker.DownloadModels;

namespace BattleFieldTracker.ViewModels
{
    public class PlayerStatsViewModel : BaseViewModel
    {
        #region Private Members

        private string _displayName;
        private string _rankImage;
        private string _rankName;
        private int _rank;
        private float _currentXp;
        private float _totalXp;
        private float _kills;
        private float _deaths;
        private float _wins;
        private float _losses;
        private int _spm;
        private int _kpm;
        private double _timePlayed;
        private string _topPrimary;
        private string _topSecondary;
        private string _topVehicle;
        private string _topClass;

        private bool _downloadFinished;

        #endregion

        //private List<Highlight> _highlights;

        #region Public Members

        public string DisplayName
        {
            get => _displayName;
            set => Set(ref _displayName, value);
        }

        public string RankImage
        {
            get => _rankImage;
            set => Set(ref _rankImage, value);
        }

        public string RankName
        {
            get => _rankName;
            set => Set(ref _rankName, value);
        }

        public int Rank
        {
            get => _rank;
            set => Set(ref _rank, value);
        }

        public float CurrentXp
        {
            get => _currentXp;
            set => Set(ref _currentXp, value);
        }

        public float TotalXp
        {
            get => _totalXp;
            set => Set(ref _totalXp, value);
        }

        public float Kills
        {
            get => _kills;
            set => Set(ref _kills, value);
        }

        public float Deaths
        {
            get => _deaths;
            set => Set(ref _deaths, value);
        }

        public float Wins
        {
            get => _wins;
            set => Set(ref _wins, value);
        }

        public float Losses
        {
            get => _losses;
            set => Set(ref _losses, value);
        }

        public int Spm
        {
            get => _spm;
            set => Set(ref _spm, value);
        }

        public int Kpm
        {
            get => _kpm;
            set => Set(ref _kpm, value);
        }

        public double TimePlayed
        {
            get => _timePlayed;
            set => Set(ref _timePlayed, value);
        }

        public string TopClass
        {
            get => _topClass;
            set => Set(ref _topClass, value);
        }

        public string TopVehicle
        {
            get => _topVehicle;
            set => Set(ref _topVehicle, value);
        }

        public string TopPrimary
        {
            get => _topPrimary;
            set => Set(ref _topPrimary, value);
        }

        public string TopSecondary
        {
            get => _topSecondary;
            set => Set(ref _topSecondary, value);
        }

        public bool DownloadFinished
        {
            get => _downloadFinished;
            set => Set(ref _downloadFinished, value);
        }

        #endregion

        //        public List<Highlight> Highlights
        //        {
        //            get => _highlights;
        //            set => Set(ref _highlights, value);
        //        }

        public void DownloadPlayerStats(string playerName)
        {
            var download = new DownloadPlayerStats();
            RootObjectPlayerStats root = download.GetDownloadData(playerName);
            ApplyData(root);
            DownloadFinished = true;
        }

        private void ApplyData(RootObjectPlayerStats root)
        {
            if (root == null)
            {
                MessageBox.Show(Validation.SharedInstance.ErrorMessage);
                return;
            }

            var stats = root.result.gameStats.tunguska;
            
            DisplayName = root.profile.displayName;
            RankImage = root.bbPrefix + GetCorrectImageUrl(stats.rank.imageUrl);
            Rank = stats.rank.number;
            RankName = stats.rank.name;
            CurrentXp = stats.rankProgress.current;
            TotalXp = stats.rankProgress.total;
            Kills = stats.kills;
            Deaths = stats.deaths;
            Wins = stats.wins;
            Losses = stats.losses;
            Spm = (int)stats.spm;
            Kpm = (int)stats.kpm;
            TimePlayed = stats.timePlayed / 3600; //Hours

            var highlights = stats.highlightsByType;
            TopClass = highlights.kit[0].kitId;
            TopVehicle = highlights.vehicle[0].name;
            TopPrimary = highlights.primary[0].name;
            TopSecondary = highlights.sidearm[0].name;
        }

        private string GetCorrectImageUrl(string url)
        {
            var correctUrl = "";

            //urls begin with '[BB_Prefix]'

            correctUrl = url.Substring(11);

            return correctUrl;
        }
    }
}
