using System.Collections.Generic;
using GoEvent.Core.Models;

namespace GoEvent.Core.Repositories
{
    public interface IFollowingRepository
    {
        IEnumerable<Following> GetFolloweesOfUser(string userId);
        bool GetFollowing(string userId, string artistId);
        IEnumerable<ApplicationUser> GetOnlyFolloweesOfUser(string userId);
    }
}