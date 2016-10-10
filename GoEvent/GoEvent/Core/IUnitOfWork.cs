using GoEvent.Core.Repositories;

namespace GoEvent.Core
{
    public interface IUnitOfWork
    {
        IEventRepository Events { get; }
        IAttendenceRepository Attendence { get; }
        IFollowingRepository Following { get; }
        IGenreRepository Genre { get; }
        void Complete();
    }
}