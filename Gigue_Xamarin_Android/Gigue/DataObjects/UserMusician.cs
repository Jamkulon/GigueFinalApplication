﻿namespace Gigue.DataObjects
{
    public class UserMusician 
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MusicianId { get; set; }
        public ThisMusician Musician { get; set; }
    }

}