﻿using System.Collections.Generic;

namespace Gigue.ViewModels
{
    public class vmMusiciansInstrumentsByGenre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int AppUserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool? IsMusician { get; set; }
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public bool? IsMusicianForHire { get; set; }
        public List<vmInstrument>  vmInstruments { get; set; }





    }
}