﻿namespace Gigue.DataObjects
{
    class MusicianGenre
    {
        public int MusicianId { get; set; }
        public ThisMusician Musician { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}