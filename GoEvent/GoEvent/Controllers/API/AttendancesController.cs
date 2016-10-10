using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GoEvent.Core.Dto;
using GoEvent.Core.Models;
using GoEvent.Persistence;

namespace GoEvent.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendancesDto dto)
        {
            var artistId = User.Identity.GetUserId();
            var exists = _dbContext.Attendances.Any(a => a.AttendeeId == artistId && a.EventId == dto.EventId);
            if (exists)
                return BadRequest("The attendance is already exists.");
            var attendance = new Attendance
            {
                EventId = dto.EventId,
                AttendeeId = artistId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId=User.Identity.GetUserId();

            var attendance = _dbContext.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.EventId == id);
            if (attendance == null)
                return NotFound();

            _dbContext.Attendances.Remove(attendance);
            _dbContext.SaveChanges();

            return Ok(id);
        }
    }
}
