using System;
using System.Collections.Generic;
using System.Linq;
using MovieMiderm.Interfaces;
using static MovieMiderm.Constants.Constants;

namespace MovieMiderm.Classes
{
    public class FindMovies : PrintMovies
    {
        private IList<IMovie> _moviesToReturn;

        public void GetMoviea(IList<IMovie> movies, string searchCriteria, string propertyTypeCode)
        {
            ResetMoviesToReturn();
            _moviesToReturn = FindMoviesByCriteria(movies, searchCriteria, propertyTypeCode);
            Print(_moviesToReturn);
        }

        private IList<IMovie> FindMoviesByCriteria(IList<IMovie> movies, string searchCriteria, string propertyTypeCode)
        {
            switch (propertyTypeCode)
            {
                case PropertyTypeCodes.MOVIE_NAME:
                    return movies.Where(x => string.Equals(x.MovieName, searchCriteria, StringComparison.OrdinalIgnoreCase)).ToList();
                case PropertyTypeCodes.ACTOR_NAME:
                    return movies.Where(x => string.Equals(x.ActorName, searchCriteria, StringComparison.OrdinalIgnoreCase)).ToList();
                case PropertyTypeCodes.GENRE:
                    return movies.Where(x => string.Equals(x.Genre, searchCriteria, StringComparison.OrdinalIgnoreCase)).ToList();
                case PropertyTypeCodes.DIRECTOR:
                    return movies.Where(x => string.Equals(x.Director, searchCriteria, StringComparison.OrdinalIgnoreCase)).ToList();
                default:
                    return null;
            }
        }

        private void ResetMoviesToReturn()
        {
            if (_moviesToReturn == null)
                _moviesToReturn = new List<IMovie>();

            else
                _moviesToReturn.Clear();
        }
    }
}