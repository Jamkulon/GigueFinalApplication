using System.Collections.Generic;

namespace Gigue.DataObjects
{
    class Instrument
    {
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public ICollection<MusicianInstrument> MusicianInstruments { get; set; }
    }
}