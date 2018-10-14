using System.Collections.Generic;
using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class GetMoviesFromTextFile
    {
        private static IList<IMovie> _movies;

        public static IList<IMovie> GetMovies()
        {
            var movies = System.IO.File.ReadAllLines(@"C:/Users/Brenden/source/repos/MovieMiderm/MovieMiderm/MoviesList.txt");

            _movies = new List<IMovie>();

            foreach (var movie in movies)
            {
                var newMovie = new Movie(movie.Split(',')[0], movie.Split(',')[1], movie.Split(',')[2], movie.Split(',')[3]);
                _movies.Add(newMovie);
            }

            return _movies;
        }
    }
}