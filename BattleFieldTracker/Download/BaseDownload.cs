﻿using System;
using BattleFieldTracker.JsonConverter;

namespace BattleFieldTracker.Download
{
    abstract class BaseDownload
    {
        protected readonly Uri BaseAddress = new Uri("https://battlefieldtracker.com/bf1/api/");
        protected readonly string HeaderName = "trn-api-key";
        protected readonly string HeaderContent = "ca114f4c-713b-49f2-98f7-56f731309348";

        protected string ContentAddress { get; set; }
        protected string Response { get; set; }
        protected ConverterJson Converter = new ConverterJson();
    }
}