﻿using GigHub.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Controllers.Api
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public GigDto Gig { get;  set; }

    }
}