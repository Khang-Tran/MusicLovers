using System.Collections.Generic;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.Contracts.Repositories.Contracts
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int gigId, string attendeeId);
        bool IsExisted(int gigId, string attendeeId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);

    }
}