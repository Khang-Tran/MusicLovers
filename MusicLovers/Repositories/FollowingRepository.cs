using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.Contracts.Repositories.Contracts;
using MusicLovers.Core.Models;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence;

namespace MusicLovers.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Following GetFollowing(string artistId, string followerId)
        {
            return _context.FollowingSet
                .SingleOrDefault(a => a.FolloweeId == artistId && a.FollowerId == followerId);
        }

        public bool IsExist(string followerId, string followeeId)
        {
            return _context.FollowingSet
                .Any(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
        }

        public IEnumerable<ApplicationUser> GetAllFollowee(string followerId)
        {
            return _context.FollowingSet
                .Where(f => f.FollowerId == followerId)
                .Select(g => g.Followee)
                .ToList();
        }

        public void Add(Following follow)
        {
            _context.FollowingSet.Add(follow);
        }

        public void Remove(Following follow)
        {
            _context.FollowingSet.Remove(follow);
        }
    }
}