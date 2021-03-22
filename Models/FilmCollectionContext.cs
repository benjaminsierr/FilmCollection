using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext (DbContextOptions<FilmCollectionContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
