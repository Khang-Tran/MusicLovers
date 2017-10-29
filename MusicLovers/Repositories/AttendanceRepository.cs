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
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.AttendanceSet
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(int gigId, string attendeeId)
        {
            return _context.AttendanceSet
            .SingleOrDefault(a => a.AttendeeId == attendeeId && a.GigId == gigId);
        }

        public bool IsExisted(int gigId, string attendeeId)
        {
            return _context.AttendanceSet.Any(a => a.AttendeeId == attendeeId && a.GigId == gigId);
        }

        public void Add(Attendance attendance)
        {
            _context.AttendanceSet.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.AttendanceSet.Remove(attendance);
        }
    }
}