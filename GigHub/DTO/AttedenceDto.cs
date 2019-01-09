using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.DTO
{/// <summary>
/// I use this class to pass data from View to Controller ,
/// the passed parameter is of type GigID
/// Check  Views : Home/Index  => Controllers /Attendece
/// </summary>
    public class AttedenceDto
    {
        public int GigId { get; set; }
        public int passedParam2 { get; set; }
        public string passedParam3 { get; set; }
    }
}