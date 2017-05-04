using System.Collections.Generic;

namespace Gigue.DataObjects
{
    class SpokenLanguage
    {
        public int SpokenLanguageId { get; set; }
        public string Language { get; set; }
        public ICollection<MusicianLanguage> MusicianLanguages { get; set; }
    }
}