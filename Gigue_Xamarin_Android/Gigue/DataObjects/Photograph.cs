﻿using System.Collections.Generic;

namespace Gigue.DataObjects
{
    public class Photograph
    {
        public int PhotographId { get; set; }
        public string PhotographURL { get; set; }
        public ICollection<MusicianPhotograph> MusicianPhotographs { get; set; }
    }
}