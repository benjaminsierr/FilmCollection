using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FilmCollection.Models.ViewModels;
using System.Net.Http;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private MoviesDbContext Context;
        private Movie DeletedMovie;
        private Movie ToEdit;
        private Movie EditedMovie;
        public HomeController(ILogger<HomeController> logger, MoviesDbContext con)
        {
            _logger = logger;
            Context = con;
        }

        public IActionResult Index()
        {
            Context.Database.EnsureCreated();
            return View();
        }

        [HttpGet("NewMovie")]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost("NewMovie")]
        public IActionResult NewMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Context.Movies.Add(movie);
            Context.SaveChanges();
            return View("Movies",new MovieList
            {
                Movies = Context.Movies.Where(x => x.Title != "Independence Day")
            });
        }



        public IActionResult Movies()
        {
            return View(new MovieList
            {
                Movies = Context.Movies.Where(x => x.Title != "Independence Day")
            });;
        }

        
        public IActionResult EditMovie(Movie movie)
        {
            if (Request.Method == "POST")
            {
                EditedMovie = movie;
                Context.SaveChanges();
                return View("Movies", new MovieList
                {
                    Movies = Context.Movies
                }); ;
            }
            ToEdit = Context.Movies.First(x => x.MovieID == movie.MovieID);
            return View("EditMovie", ToEdit);
        }


        [HttpPost("DeleteMovie")]
        public IActionResult DeleteMovie(Movie movie)
        {
            DeletedMovie = Context.Movies.First(x => x.MovieID != movie.MovieID);
            Context.Movies.Remove(DeletedMovie);
            Context.SaveChanges();
            return View("Movies", new MovieList
            {
                Movies = Context.Movies.Where(x => x.Title != "Independence Day")
            }); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Podcast()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
