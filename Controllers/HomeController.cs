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
        public int mid;
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

        public IActionResult EditMoviePage(int id)
        {
            Number.mid = id;
            ToEdit = Context.Movies.First(x => x.MovieID == id);
            return View("EditMovie", ToEdit);
        }
        public IActionResult EditMovie(Movie movie)
        {
            if (Request.Method == "POST")
            {

                movie.MovieID = Number.mid;
                Context.Update(movie);
                Context.SaveChanges();
                return View("Movies", new MovieList
                {
                    Movies = Context.Movies.Where(x => x.Title != "Independence Day")
                }); ;
            }
            else
            {
                return View("Index");
            }
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
