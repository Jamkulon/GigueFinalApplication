using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.ViewModels
{
    public class vmMusician
    {
        //Properties.
        public int MusicianId { get; set; }
        public string StageName { get; set; }
        public string CellPhone { get; set; }
        public string Biography { get; set; }
        public decimal? Rate { get; set; }
        public int? Rating { get; set; }

    }
}