using System;
using GigHub.Models;

namespace GigHub.DTO
{
    public class GigDto
    {
        public int Id { get; set; }
        public ApplicationUser Artist { get; set; }//the app user,the artist who created the party
        public DateTime DateTime { get; set; }
        public GenereDto GenereDto { get; set; }
        public byte GenereId { get; set; }//byte as Gene is defined as byte
        public string Venue { get; set; }
        public bool IsCancelled { get;  set; }
        /*mainly remove navigation properties,
         data annotation
         non Imp Id
        */
    }
}