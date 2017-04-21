using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class MusicianGenre
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}