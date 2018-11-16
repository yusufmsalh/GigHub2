using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Models;

namespace GigHub.Migrations
{
    public class Gig
    {
        public int Id { get; set; }
        public ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genere Genere { get; set; }
    }
}