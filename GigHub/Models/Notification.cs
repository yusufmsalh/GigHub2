using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        [Required]// force a notification to have a required gig
        public Gig Gig { get;  private set; }


        public Notification()
        {
            
        }

        public Notification(Gig gig,NotificationType type)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("gig cannot be null inside notification class");
            }
            Gig = gig;
            DateTime = DateTime.Now;
            Type = type;

        }



    }
}