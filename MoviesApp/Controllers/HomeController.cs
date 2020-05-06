using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using static MoviesApp.Models.MovieRepository;

namespace MoviesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        
        public IActionResult Index()
        {
            MovieVM model = new MovieVM();
            model.Movies = _movieRepository.Movies;

            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string title)
        {
            if (title == null || title.Trim().Length == 0)
                return RedirectToAction("Index");
            MovieVM model = new MovieVM();
            model.Movies = _movieRepository.Movies.Where(x => x.Title.Contains(title.Trim())).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
