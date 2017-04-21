using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class UserMusicianRating
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int MusicianRating { get; set; }
        public DateTime? DateTimeOfRating { get; set; }
    }
}