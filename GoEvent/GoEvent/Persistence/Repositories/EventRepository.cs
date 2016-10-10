using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GoEvent.Core.Models;
using GoEvent.Core.Repositories;

namespace GoEvent.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public Event GetEvent(int eventId)
        {
            return _dbContext.Events
                .Include(a => a.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == eventId);
        }

        public Event GetEventWithAttendees(int eventId)
        {
            return _dbContext.Events
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == eventId);
        }

        public IEnumerable<Event> GetEventsUserAttending(string userId)
        {
            return _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(g => g.Event)
                .Include(a => a.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public IEnumerable<Event> GetUpcomingEventsByArtist(string artistId)
        {
            return _dbContext.Events
                .Where(g => g.ArtistId == artistId &&
                            g.DateTime > DateTime.Now &&
                            !g.IsCancel)
                .Include(g => g.Genre)
                .ToList();
        }

        public void Add(Event evento)
        {
            _dbContext.Events.Add(evento);
        }

        public IEnumerable<Event> SearchEvents(IEnumerable<Event> events, string search)
        {
            return events
                .Where(g =>
                    g.Artist.Name.Contains(search) ||
                    g.Genre.Name.Contains(search) ||
                    g.Venue.Contains(search));
        }

        public IEnumerable<Event> GetUpcomingEvents()
        {
            return _dbContext.Events
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCancel);
        }
    }
}