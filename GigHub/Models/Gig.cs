using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Models;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Migrations
{
    public class Gig
    {
        public int Id { get; set; }
        
        public ApplicationUser Artist { get; set; }
        [Required] 
        public string ArtistId { get; set; }//string as application user. id
        [Required]
        public byte GenereId { get; set; }//byte as Gebe is defined as byte
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        public Genere Genere { get; set; }

    }
}