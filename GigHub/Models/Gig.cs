using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        
        public ApplicationUser Artist { get; set; }//the app user,the artist who created the party
        public DateTime DateTime { get; set; }
        public Genere Genere { get; set; }

        [Required]  
        public string ArtistId { get; set; }//string as application user. id
        [Required]
        public byte GenereId { get; set; }//byte as Gene is defined as byte


        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
    }
}