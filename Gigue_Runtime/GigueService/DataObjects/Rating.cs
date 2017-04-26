using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigueService.Models
{
    public class Rating : EntityData
    {
        public string MusicianRating { get; set; }
    }
}