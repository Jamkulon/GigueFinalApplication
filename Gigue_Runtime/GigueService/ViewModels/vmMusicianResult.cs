using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.ViewModels
{
    public class vmMusicianResult
    {
        public int AppUserId { get; set; }
        public string StageName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PrimeInstrument { get; set; }

    }
}