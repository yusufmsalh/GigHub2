using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper.Mappers;

namespace GigHub.ViewModels
{
    public class GigViewModelv2
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
        public bool IsCancelled { get; private set; }
        public ICollection<Attendence> Attendence { get; private set; }
        public bool isGoing { get; set; }
        public GigViewModelv2()
        {
            Attendence = new Collection<Attendence>();
        }
    }
}