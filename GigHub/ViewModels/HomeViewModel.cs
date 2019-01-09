using System.Collections.Generic;
using System.Linq;
using GigHub.Migrations;

namespace GigHub.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public bool IsAuthenticated { get; set; }
        public IEnumerable<Gig> UpComingGigs { get; set; }//use IEnum as you need to extend query ,just want to loop over it.
    }
}