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
        //set global variables
        private readonly ILogger<HomeController> _logger;
        private MoviesDbContext Context;
        private Movie DeletedMovie;
        private Movie ToEdit;
        public int mid;
        //constructor; set context
        public HomeController(ILogger<HomeController> logger, MoviesDbContext con)
        {
            _logger = logger;
            Context = con;
        }
        //return view; make sure db is created
        public IActionResult Index()
        {

            Context.Database.EnsureCreated();
            return View();
        }

        //show new movie form on GET
        [HttpGet("NewMovie")]
        public IActionResult NewMovie()
        {
            return View();
        }

        //add movie to DB on POST; send to Moies page
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
                Movies = Context.Movies.Where(x => x.Title != "Independence Day") //dont show Independence day
            });
        }


        //return movies on movies view
        public IActionResult Movies()
        {
            return View(new MovieList
            {
                Movies = Context.Movies.Where(x => x.Title != "Independence Day")
            });;
        }
        //send to edit movie form page
        public IActionResult EditMoviePage(int id)
        {
            //set id of movie
            Number.mid = id;
            //find movie and send in view
            ToEdit = Context.Movies.First(x => x.MovieID == id);
            return View("EditMovie", ToEdit);
        }
        //updaet db and return to movies page with movies
        public IActionResult EditMovie(Movie movie)
        {
            if (Request.Method == "POST")
            {

                movie.MovieID = Number.mid;
                Context.Update(movie);
                Context.SaveChanges();
                return View("Movies", new MovieList
                {
                    Movies = Context.Movies.Where(x => x.Title != "Independence Day") // no I.D. again
                }); ;
            }
            else
            {
                return View("Index");
            }
        }

        //delete movie when button is pressed; return to movies
        [HttpPost("DeleteMovie")]
        public IActionResult DeleteMovie(Movie movie)
        {
            DeletedMovie = Context.Movies.First(x => x.MovieID != movie.MovieID);
            Context.Movies.Remove(DeletedMovie);
            Context.SaveChanges();
            return View("Movies", new MovieList
            {
                Movies = Context.Movies.Where(x => x.Title != "Independence Day") // no I.D.
            }); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        //return podcast page
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
