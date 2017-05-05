using System;

namespace Gigue.DataObjects
{
    class UserMusicianRating
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MusicianId { get; set; }
        public ThisMusician Musician { get; set; }
        public int MusicianRating { get; set; }
        public DateTime? DateTimeOfRating { get; set; }
    }
}