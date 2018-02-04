namespace BattleFieldTracker.Helper
{
    /// <summary>
    /// Takes the given string and forms the correct url
    /// </summary>
    public class ImageUrlGenerator
    {
        /// <summary>
        /// Base Url for the battlefield assets
        /// </summary>
        private const string BbPrefix = "https://eaassets-a.akamaihd.net/battlelog/battlebinary";

        /// <summary>
        /// Takes the uncomplete url, cuts it and returns the correct one
        /// </summary>
        /// <param name="url">The uncomplete url within the download data</param>
        /// <returns>Img Url</returns>
        public string SetCorrectImageUrl(string url)
        {
            //urls begin with '[BB_Prefix]'

            string correctUrl = BbPrefix + url.Substring(11);

            return correctUrl;
        }
    }
}
