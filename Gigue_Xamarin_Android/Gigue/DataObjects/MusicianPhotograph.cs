namespace Gigue.DataObjects
{
    class MusicianPhotograph
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int PhotographId { get; set; }
        public Photograph Photograph { get; set; }
    }
}