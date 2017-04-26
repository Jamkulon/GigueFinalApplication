using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class Genre : EntityData
    {
      
        public string GenreName { get; set; }
        public ICollection<MusicianGenre> MusicianGenres { get; set; }
    }
}