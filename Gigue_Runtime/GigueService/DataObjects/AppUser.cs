﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class AppUser : EntityData
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool? ReceiveAdvertisements { get; set; }
        public bool? IsMusicianForHire { get; set; }
        public ICollection<UserMusician> Musicians { get; set; }
        public ICollection<UserFavoriteMusician> UserFavoriteMusicians { get; set; }
        public ICollection<UserMusicianRating> UserMusicianRatings { get; set; }
    }
}
