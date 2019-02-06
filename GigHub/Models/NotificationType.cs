using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Models
{/// <summary>
/// Enum that represents Types of Notifications
/// </summary>
    public enum NotificationType
    {
        GigCancelled = 1,
        GigUpdated = 2,
        GigCreated = 3
    }
}