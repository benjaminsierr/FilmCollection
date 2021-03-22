using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FilmCollection.Models.ViewModels;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FilmCollectionRepository _repository;
        public HomeController(ILogger<HomeController> logger, FilmCollectionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
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
            

            return View("Movies");
        }



        public IActionResult Movies()
        {
            return View(new MovieList
            {
                Movies = _repository.Movies
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
