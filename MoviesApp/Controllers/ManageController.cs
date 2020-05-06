using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using static MoviesApp.Models.MovieRepository;

namespace MoviesApp.Controllers
{
    public class ManageController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public ManageController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Movie()
        {
            MovieVM model = new MovieVM();
            model.Movies = _movieRepository.Movies;
            model.Movie = new Movie();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            if (movie.Id != 0)
            {
                _movieRepository.Edit(movie);
            }
            else
            {
                _movieRepository.Create(movie);
            }
            
            return RedirectToAction("Movie");
        }

        public IActionResult EditMovie(int Id)
        {
            Movie model = _movieRepository.Movies.Where(x => x.Id == Id).FirstOrDefault();
            return PartialView("~/Views/Manage/CreateMovie.cshtml", model);
        }

       

    }
}