using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class MusicianPhotograph
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int PhotographId { get; set; }
        public Photograph Photograph { get; set; }
    }
}