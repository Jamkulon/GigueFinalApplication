using System.Collections.Generic;

namespace Gigue.DataObjects
{
    public class AppUser 
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
        public bool? IsMusician { get; set; }
        //public ICollection<UserMusician> UserMusicians { get; set; }
        //public ICollection<UserFavoriteMusician> UserFavoriteMusicians { get; set; }
        //public ICollection<UserMusicianRating> UserMusicianRatings { get; set; }
    }
}
