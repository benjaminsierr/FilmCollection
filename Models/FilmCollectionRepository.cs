using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public interface FilmCollectionRepository
    {
        IQueryable<Movie> Movies { get; }
    }
}
