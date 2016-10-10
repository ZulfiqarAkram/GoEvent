using GoEvent.Core;
using GoEvent.Core.Repositories;
using GoEvent.Persistence.Repositories;

namespace GoEvent.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEventRepository Events { get; private set; }
        public IAttendenceRepository Attendence { get; private set; }
        public IFollowingRepository Following { get; private set; }
        public IGenreRepository Genre { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
            Events=new EventRepository(_dbContext);
            Attendence=new AttendenceRepository(_dbContext);
            Following=new FollowingRepository(_dbContext);
            Genre=new GenreRepository(_dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }
    }
}