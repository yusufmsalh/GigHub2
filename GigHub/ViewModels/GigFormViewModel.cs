﻿using GigHub.Migrations;
using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDateValidation]
        public string Date { get; set; }

        [Required]
        [FutureTimeValidation]
        public string Time { get; set; }

        [Required(ErrorMessage = "Please Choose Genere")]
        public byte Genere { get; set; }
        public List<Genere> Generes { get; set; }//List of Geners from DB

        public DateTime GetDateTime()//Method not prop to avoid Exception caused by reflection in posting back in invalid model state
        {
            return DateTime.Now;
            return DateTime.Parse(string.Format("{0} {1}", Date, Time)); // fix it later
        }
        public string Heading { get; set; }// use it to to change the heading of view ,as it's shared among multiple actions
        public string ActionToBeCalled
        {
            get { return (Id != 0) ? "Edit" : "Create"; }
        }
    }
}