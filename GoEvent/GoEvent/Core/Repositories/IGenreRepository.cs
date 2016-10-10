using System.Collections.Generic;
using GoEvent.Core.Models;

namespace GoEvent.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}