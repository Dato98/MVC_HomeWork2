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
        private const string MovieFormPartialView = "~/Views/Manage/CreateMovie.cshtml";

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

        public IActionResult CreateMovie()
        {
            return PartialView(MovieFormPartialView, new Movie());
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

            
            return PartialView("~/Views/Manage/TableRows.cshtml",GetMovieModel());
        }

        public IActionResult EditMovie(int Id)
        {
            // Movie model = _movieRepository.Movies.Where(x => x.Id == Id).FirstOrDefault();
             Movie movie = new Movie();
             if (Id > 0)
             {
                 movie = _movieRepository.GetMovieById(Id);
             }
            return PartialView(MovieFormPartialView, movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            _movieRepository.Edit(movie);
            return PartialView("~/Views/Manage/TableRows.cshtml", GetMovieModel());
        }


        private MovieVM GetMovieModel()
        {
            MovieVM model = new MovieVM();
            model.Movies = _movieRepository.Movies;
            return model;
        }
    }
}