using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public  static class MovieList
    {
        private static List<Movie> movies = new List<Movie>();

        public static IEnumerable<Movie> Movies => movies;

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
