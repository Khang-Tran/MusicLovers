using System.Collections.Generic;
using MusicLovers.Core.Models;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.Contracts.Repositories.Contracts
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string artistId, string followerId);
        bool IsExist(string followerId, string followeeId);
        IEnumerable<ApplicationUser> GetAllFollowee(string followerId);

        void Add(Following follow);
        void Remove(Following follow);
    }
}