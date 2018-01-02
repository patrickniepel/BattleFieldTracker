namespace BattleFieldTracker.Helper
{
    /// <summary>
    /// Takes the given string and forms the correct url
    /// </summary>
    public class ImageUrlGenerator
    {
        private const string BbPrefix = "https://eaassets-a.akamaihd.net/battlelog/battlebinary";

        public string SetCorrectImageUrl(string url)
        {
            //urls begin with '[BB_Prefix]'

            string correctUrl = BbPrefix + url.Substring(11);

            return correctUrl;
        }
    }
}
