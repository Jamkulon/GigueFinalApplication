namespace Gigue.DataObjects
{
    public class MusicianInstrument 
    {
        public int MusicianId { get; set; }
        public ThisMusician Musician { get; set; }
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        public bool? IsPrimary { get; set; }

    }
}