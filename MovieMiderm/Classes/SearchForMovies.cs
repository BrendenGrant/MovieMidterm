using System;
using System.Collections.Generic;
using System.Linq;
using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class SearchForMovies : ISearchForMovies
    {
        public IList<IMovie> SearchByMovieName(string movieName, IList<IMovie> movies)
        {
            return movies.Where(x => x.MovieName.Contains(movieName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IList<IMovie> SearchByActorName(string actorName, IList<IMovie> movies)
        {
            return movies.Where(x => x.MainActorName.Contains(actorName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IList<IMovie> SearchByGenre(string genre, IList<IMovie> movies)
        {
            return movies.Where(x => x.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IList<IMovie> SearchByDirector(string director, IList<IMovie> movies)
        {
            return movies.Where(x => x.Director.Contains(director, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}