using System.Net;
using System.Net.Http;

namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Validates the first response of the server
    /// </summary>
    public class Validation
    {
        public static readonly Validation SharedInstance = new Validation();
        private Validation() { }

        public bool IsError { get; private set; }

        public string ErrorMessage { get; private set; }

        public void ValidateDownload(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                IsError = true;
                ErrorMessage = "Spieler konnte nicht gefunden werden";
            }
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                IsError = true;
                ErrorMessage = "Server Error";
            }
        }
    }
}
