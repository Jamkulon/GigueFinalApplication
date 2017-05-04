using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.ViewModels
{
    public class vmMusiciansInstrumentsByGenre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int AppUserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool? IsMusicianForHire { get; set; }
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public List<vmInstrument>  vmInstruments { get; set; }





    }
}