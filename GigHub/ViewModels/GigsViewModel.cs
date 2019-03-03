using System.Collections.Generic;
using System.Linq;
using GigHub.Migrations;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigsViewModel
    {
        public GigsViewModel()
        {
        }

        public bool IsAuthenticated { get; set; }
        public IEnumerable<Gig> UpComingGigs { get; set; }
        public string SearchTerm { get; set; }
        public bool Type { get; set; }
        public bool IsGoing { get; set; }
        public ILookup<int, Attendence> MyAttendences { get;  set; }
        /*
         *ILookUp is simialr to a dictionary
         *int : gig id ,key to look by
         * Attendence : the value(type of elements) to look for.
         */
    }
}