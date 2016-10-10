using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GoEvent.Core.Dto;
using GoEvent.Core.Models;
using GoEvent.Persistence;

namespace GoEvent.Controllers.API
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId);
            if (exists)
                return BadRequest("Following already register");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _dbContext.Followings
                .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);

            if (following == null)
                return NotFound();

            _dbContext.Followings.Remove(following);
            _dbContext.SaveChanges();

            return Ok(id);

        }

    }
}