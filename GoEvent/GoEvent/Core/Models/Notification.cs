using System;

namespace GoEvent.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        public Event Event { get; private set; }

        public Notification()
        {
            
        }
        public  Notification(Event evento ,NotificationType type)
        {
            if(evento==null)
                throw new ArgumentNullException("Event");

            Event = evento;
            Type = type;
            DateTime=DateTime.Now;
        }

        public static Notification EventCreated(Event evento)
        {
            return  new Notification(evento,NotificationType.EventCreated);
        }
        
        public static Notification EventUpdated(Event evento,DateTime originalDateTime,string originalVenue)
        {
            var notification=  new Notification(evento,NotificationType.EventUpdated);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification EventCanceled(Event evento)
        {
            return  new Notification(evento,NotificationType.EventCanceled);
        }
    }
}