﻿using Microsoft.Azure.Mobile.Server;

namespace GigueService.Models
{
    public class UserMusician : EntityData
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}