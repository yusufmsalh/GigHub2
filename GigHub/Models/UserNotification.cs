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

        public ApplicationUser User { get; private  set; }

        public Notification Notification { get;  private  set; }

        public bool IsRead { get; set; }


        public UserNotification( ApplicationUser user, Notification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification cannot be null inside UserNotification Class");
            if (user == null)
                throw new ArgumentNullException("user cannot be null inside UserNotification Class");
            User = user;
            Notification = notification;



        }

        public UserNotification()
        {
            
        }
    }
}