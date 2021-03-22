using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models.ViewModels
{
    public class MovieList
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
