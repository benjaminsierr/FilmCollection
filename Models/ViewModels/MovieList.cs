using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//create list of movies 
namespace FilmCollection.Models.ViewModels
{
    public class MovieList
    {
        public IQueryable<Movie> Movies { get; set; }
    }
}
