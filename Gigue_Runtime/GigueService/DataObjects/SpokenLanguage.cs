﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class SpokenLanguage
    {
        public int SpokenLanguageId { get; set; }
        public string Language { get; set; }
        public ICollection<MusicianLanguage> MusicianLanguages { get; set; }

    }
}