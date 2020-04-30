using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class MovieRepository
    {
        public interface IMovieRepository
        {
            IEnumerable<Movie> Movies { get;}

            void Create(Movie movie);
        }


        public class MoviRepository : IMovieRepository
        {
            private List<Movie> Data = new List<Movie>()
            {
                new Movie(1,"https://static.imovies.cc/movies/covers/510/810/878455810-1143c333ad1fe5518a337aa6a8037fa7.jpg","დახსნა"),
                new Movie(2,"https://static.imovies.cc/movies/covers/510/276/878369276-9fd3b3ece2f8bc926ab4f55e626d5d34.jpg","შურისმაძიებლები")
            };

            public IEnumerable<Movie> Movies => Data;

            public void Create(Movie movie)
            {
                var mv = Data.OrderBy(x => x.Id).LastOrDefault();
                movie.Id = mv != null ? mv.Id + 1 : 1;
                Data.Add(movie);
            }
        }
    }
}
