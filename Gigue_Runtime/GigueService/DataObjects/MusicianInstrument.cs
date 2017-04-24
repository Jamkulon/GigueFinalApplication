using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class MusicianInstrument : EntityData
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}