using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class Photograph : EntityData
    {
        public string PhotographURL { get; set; }
        public ICollection<MusicianPhotograph> MusicianPhotographs { get; set; }
    }
}