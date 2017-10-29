using MusicLovers.Core.Contracts.Repositories.Contracts;

namespace MusicLovers.Core.Contracts
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IGenreRepository Genres { get; }
        IFollowingRepository Followings { get; }
        IAttendanceRepository Attendances { get; }
        INotificationRepository Notifications { get; }
        void Complete();
    }
}