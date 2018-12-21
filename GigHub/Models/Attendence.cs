using GigHub.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Attendence
    {
        public Gig Gig { get; set; }//The Party
        public ApplicationUser Attender { get; set; }
        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }//f.key to save eager loading entier gig,just add key
        [Key]
        [Column(Order = 2)]
        public string AttenderId { get; set; }// f.key ,application user has Id as string
        /*The key twice : is a composite key ,as every combination is a unique user attending a party*/
        /*use the column order attribute as a must in defining  a composite key.*/
    }
}