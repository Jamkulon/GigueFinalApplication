namespace Gigue.DataObjects
{
    public class MusicianLanguage 
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int SpokenLanguageId { get; set; }
        public SpokenLanguage SpokenLanguage { get; set; }
        public bool? IsPrimary { get; set; }

    }
}