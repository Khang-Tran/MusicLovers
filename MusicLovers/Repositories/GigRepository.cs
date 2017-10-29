using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.Contracts.Repositories.Contracts;
using MusicLovers.Core.Models;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Persistence;

namespace MusicLovers.Repositories
{
    public class GigRepository : IGigRepository
    {
        private ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.AttendanceSet
                .Where(a => a.AttendeeId == userId)
                .Select(g => g.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigWithAttendee(int gigId)
        {
            return _context.GigSet
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetGigWithGenre(int gigId)
        {
            return _context.GigSet.Include(g => g.Genre).ToList();
        }

        public Gig GetGigWithId(int gigId)
        {
            return _context.GigSet
                .Include(g=>g.Genre)
                .Include(g=>g.Artist)
                .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetAllUpcomingGigs()
        {
            return _context.GigSet
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCancel);
        }


        public IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId)
        {
            return _context.GigSet
                .Where(g=>g.ArtistId == artistId && g.DateTime > DateTime.Now && !g.IsCancel)
                .Include(g=>g.Genre)
                .Include(g=>g.Artist)
                .ToList();
        }

        public void Add(Gig gig)
        {
            _context.GigSet.Add(gig);
        }
    }
}