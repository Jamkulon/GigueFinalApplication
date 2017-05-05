namespace Gigue.DataObjects
{
    class MusicianInstrument
    {
        public int MusicianId { get; set; }
        public ThisMusician Musician { get; set; }
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}