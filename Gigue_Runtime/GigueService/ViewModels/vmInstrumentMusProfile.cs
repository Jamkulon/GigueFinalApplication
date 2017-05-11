using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.ViewModels
{
    public class vmInstrumentMusProfile
    {

        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public bool? PrimaryInstrument { get; set; }

    }
}