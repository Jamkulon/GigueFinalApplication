using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class Musician 
    {
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public string CellPhone { get; set; }
        public string Biography { get; set; }
        public decimal? Rate { get; set; }
        public int? Rating { get; set; }
        public ICollection<UserMusician> Users { get; set; }
        public ICollection<UserFavoriteMusician> FavoriteMusicians { get; set; }
        public ICollection<UserMusicianRating> MusicianRatings { get; set; }
        public ICollection<MusicianInstrument> Instruments { get; set; }
        public ICollection<MusicianGenre> Genres { get; set; }
        public ICollection<MusicianLanguage> MusicianLanguages { get; set; }
        public ICollection<MusicianPhotograph> MusicianPhotographs { get; set; }
    }
}