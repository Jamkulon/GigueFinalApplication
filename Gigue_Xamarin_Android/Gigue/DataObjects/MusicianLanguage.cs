namespace Gigue.DataObjects
{
    class MusicianLanguage
    {
        public int MusicianId { get; set; }
        public ThisMusician Musician { get; set; }
        public int SpokenLanguageId { get; set; }
        public SpokenLanguage SpokenLanguage { get; set; }
    }
}