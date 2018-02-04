using System;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using BattleFieldTracker.Converter;


namespace BattleFieldTracker.Download
{
    /// <summary>
    /// Abstract Download class as base for every download
    /// </summary>
    public abstract class BaseDownload
    {
        protected readonly Uri BaseAddress = new Uri("https://battlefieldtracker.com/bf1/api/");
        protected readonly string HeaderName = "trn-api-key";
        protected readonly string HeaderContent = "ca114f4c-713b-49f2-98f7-56f731309348";

        /// <summary>
        /// address for player stats, weapons, vehicles ...
        /// </summary>
        protected string ContentAddress { get; set; }

        /// <summary>
        /// Download response
        /// </summary>
        protected string Response { get; set; }

        /// <summary>
        /// Status code of the given download
        /// </summary>
        protected HttpStatusCode StatusCode { private get; set; }
        protected readonly ConverterJson Converter = new ConverterJson();

        /// <summary>
        /// Checks if there were errors while downloading and displays a message accordingly
        /// </summary>
        /// <returns>Download has no errors</returns>
        protected bool CheckForErrors()
        {
            switch (StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                case HttpStatusCode.BadRequest:
                    ShowErrorMessage("Spieler konnte nicht gefunden werden");
                    return false;
                case HttpStatusCode.InternalServerError:
                    ShowErrorMessage("Server Error");
                    return false;
            }

            ShowErrorMessage("Ein Fehler ist aufgetreten. Versuche es später erneut");
            return false;
        }

        /// <summary>
        /// Shows the given Message to the user
        /// </summary>
        /// <param name="message">The message that will be displayed</param>
        protected void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
