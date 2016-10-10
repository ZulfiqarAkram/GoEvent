using GoEvent.Core.Models;
using System.Collections.Generic;

namespace GoEvent.Core.Repositories
{
    public interface IAttendenceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        bool GetAttendance(int eventId, string userId);
    }
}