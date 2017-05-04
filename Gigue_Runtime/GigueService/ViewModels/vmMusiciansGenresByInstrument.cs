using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.ViewModels
{
    public class vmMusiciansGenresByInstrument
    {
        //Fields.

        //Properties.
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public int AppUserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool? IsMusician { get; set; }
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public bool? IsMusicianForHire { get; set; }

        public List<vmGenre> vmGenres { get; set; }

        
        //Constructor().

        //Methods().

    }
}