using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class FollowingRelation
    {
        #region Main Members
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }
        #endregion
        #region Navigation Proprties
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; } 
        #endregion


    }
}