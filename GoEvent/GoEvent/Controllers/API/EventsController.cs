using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GoEvent.Core.Models;
using GoEvent.Persistence;

namespace GoEvent.Controllers.API
{
    [Authorize]
    public class EventsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public EventsController()
        {
                _dbContext=new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var evento = _dbContext.Events
                .Include(g=>g.Attendances.Select(a=>a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);
            
            if (evento.IsCancel)
                return NotFound();

            evento.Cancel();

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
