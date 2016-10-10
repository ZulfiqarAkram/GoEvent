using System.Collections.Generic;
using System.Linq;
using GoEvent.Core.Models;
using GoEvent.Core.Repositories;

namespace GoEvent.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _dbContext;
        public FollowingRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Following> GetFolloweesOfUser(string userId)
        {
            return _dbContext.Followings
                .Where(f => f.FollowerId == userId)
                .ToList();
        }

        public bool GetFollowing(string userId, string artistId)
        {
            return _dbContext.Followings.
                Any(f => f.FollowerId == userId && f.FolloweeId == artistId);
        }

        public IEnumerable<ApplicationUser> GetOnlyFolloweesOfUser(string userId)
        {
            return _dbContext.Followings
                .Where(f => f.FollowerId == userId)
                .Select(x => x.Followee)
                .ToList();
        }
    }
}