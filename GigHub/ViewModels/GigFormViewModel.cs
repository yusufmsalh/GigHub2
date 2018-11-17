using GigHub.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genere { get; set; }

        public IEnumerable<Genere> Generes { get; set; }//List of Geners from DB

        public DateTime GetDateTime()//Method not prop to avoid Exception caused by reflection in posting back in invalid model state
        {
           return DateTime.Parse(string.Format("{0} {1}", Date, Time)); 
        }

    }
}