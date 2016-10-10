using System;
using System.Collections.Generic;
using System.Linq;
using GoEvent.Core.Models;
using GoEvent.Core.Repositories;

namespace GoEvent.Persistence.Repositories
{
    public class AttendenceRepository : IAttendenceRepository
    {
        private ApplicationDbContext _dbContext;
        public AttendenceRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _dbContext.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList();
        }


        public bool GetAttendance(int eventId, string userId)
        {
            return _dbContext.Attendances
                    .Any(g => g.EventId == eventId && g.AttendeeId == userId); ;
        }
    }
}