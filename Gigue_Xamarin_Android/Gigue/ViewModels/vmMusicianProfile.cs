using System.Collections.Generic;

namespace Gigue.ViewModels
{
    public class vmMusicianProfile
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool? ReceiveAdvertisements { get; set; }
        public bool? IsMusician { get; set; }
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public string CellPhone { get; set; }
        public string Biography { get; set; }
        public decimal? Rate { get; set; }
        public int? Rating { get; set; }
        public bool? IsMusicianForHire { get; set; }
        public List<vmInstrumentMusProfile> InstrumentsMusProfile { get; set; }
        public List<vmGenre> Genres { get; set; }
        public List<vmSpokenLanguage> Languages { get; set; }
        public List<vmPhotograph> Photographs { get; set; }
        
    }
}