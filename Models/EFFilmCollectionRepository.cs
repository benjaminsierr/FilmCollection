using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class EFFilmCollectionRepository : FilmCollectionRepository
    {
        public FilmCollectionContext _context;

        public EFFilmCollectionRepository(FilmCollectionContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
