﻿using System.Collections.Generic;

namespace Gigue.DataObjects
{
    class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<MusicianGenre> MusicianGenres { get; set; }
    }
}