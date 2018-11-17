using GigHub.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genere { get; set; }
        public IEnumerable<Genere> Generes { get; set; }//List of Geners from DB

    }
}