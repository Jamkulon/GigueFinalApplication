using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class Instrument : EntityData
    {
        public string InstrumentName { get; set; }
        public ICollection<MusicianInstrument> MusicianInstruments { get; set; }
    }
}