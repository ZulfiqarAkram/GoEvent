using GoEvent.Core.Models;
using System;

namespace GoEvent.Core.Dto
{
    public class NotificationDto
    {
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }
        public EventDto Event { get;  set; }
    }
}