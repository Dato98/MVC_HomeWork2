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
            _movieRepository.Create(movie);
            return RedirectToAction("Movie");
        }

        public IActionResult EditMovie(int Id)
        {
            Movie model = _movieRepository.Movies.Where(x => x.Id == Id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            var mov = _movieRepository.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();
            if(mov != null)
            {
                mov.Title = movie.Title;
                mov.Thumb = movie.Thumb;
            }

            return RedirectToAction("Movie");
        }

    }
}