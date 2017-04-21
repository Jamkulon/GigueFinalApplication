using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class MusicianLanguage
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int LanguageSpokenId { get; set; }
        public LanguageSpoken LanguageSpoken { get; set; }
    }
}