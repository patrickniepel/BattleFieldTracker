using System;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using BattleFieldTracker.Converter;


namespace BattleFieldTracker.Download
{
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
        protected HttpStatusCode StatusCode { private get; set; }
        protected readonly ConverterJson Converter = new ConverterJson();

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

        protected void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
