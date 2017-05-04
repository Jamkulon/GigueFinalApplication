namespace Gigue.DataObjects
{
    class UserMusician
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
    }
}