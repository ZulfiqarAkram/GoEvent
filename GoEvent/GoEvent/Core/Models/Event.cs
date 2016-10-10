using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GoEvent.Core.Models
{
    public class Event
    {
        public int Id { get; set; }
        public bool IsCancel { get; private set; }
        public ApplicationUser Artist  { get; set; }
        public string  ArtistId { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }

        public Event()
        {
            Attendances=new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancel = true;
            var notification = Notification.EventCanceled(this);
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            var notification=Notification.EventUpdated(this,DateTime,Venue);

            DateTime = dateTime;
            Venue = venue;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a=>a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Create()
        {
            Notification.EventCreated(this);
        }
    }
}