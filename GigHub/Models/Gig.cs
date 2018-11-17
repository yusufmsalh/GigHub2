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
        [Required]
        public ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        [Required]
        public Genere Genere { get; set; }
    }
}