using System.Collections.Generic;
using System.Linq;
using GoEvent.Core.Models;
using GoEvent.Core.Repositories;

namespace GoEvent.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _dbContext;
        public GenreRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }
    }
}