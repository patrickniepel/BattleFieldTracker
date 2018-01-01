using System;
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
        protected readonly ConverterJson Converter = new ConverterJson();
    }
}
