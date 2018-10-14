using MovieMiderm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMiderm.Classes
{
    public class GetMaxStringLengths
    {
        private int _maxLength;

        public int GetMaxMovieNameLength(IList<IMovie> movies)
        {
            _maxLength = 0;
            
            foreach (var movie in movies)
            {
                var currentLength = movie.MovieName.Length;
                _maxLength = Math.Max(_maxLength, currentLength);
            }

            return _maxLength;
        }

        public int GetMaxMainActorNameLength(IList<IMovie> movies)
        {
            _maxLength = 0;

            foreach (var movie in movies)
            {
                var currentLength = movie.MainActorName.Length;
                _maxLength = Math.Max(_maxLength, currentLength);
            }

            return _maxLength;
        }

        public int GetMaxGenreLength(IList<IMovie> movies)
        {
            _maxLength = 0;

            foreach (var movie in movies)
            {
                var currentLength = movie.Genre.Length;
                _maxLength = Math.Max(_maxLength, currentLength);
            }

            return _maxLength;
        }

        public int GetMaxDirectorLength(IList<IMovie> movies)
        {
            _maxLength = 0;

            foreach (var movie in movies)
            {
                var currentLength = movie.Director.Length;
                _maxLength = Math.Max(_maxLength, currentLength);
            }

            return _maxLength;
        }
    }
}