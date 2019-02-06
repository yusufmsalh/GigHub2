using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub.Models
{/// <summary>
/// This Class Represents the Association between
/// User and Notification
/// means : it 's the specific user  instance of a Notification
/// it has IsRead ,so if a specific user read his notification
/// it would be marked as Read.
/// </summary>
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]//Composite primary key
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public ApplicationUser User { get; set; }

        public Notification Notification { get; set; }

        public bool IsRead { get; set; }

    }
}