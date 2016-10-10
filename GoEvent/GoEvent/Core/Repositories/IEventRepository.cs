using GoEvent.Core.Models;
using System.Collections.Generic;

namespace GoEvent.Core.Repositories
{
    public interface IEventRepository
    {
        Event GetEvent(int eventId);
        Event GetEventWithAttendees(int eventId);
        IEnumerable<Event> GetEventsUserAttending(string userId);
        IEnumerable<Event> GetUpcomingEventsByArtist(string artistId);
        void Add(Event evento);
        IEnumerable<Event> SearchEvents(IEnumerable<Event> events, string search);
        IEnumerable<Event> GetUpcomingEvents();
    }
}