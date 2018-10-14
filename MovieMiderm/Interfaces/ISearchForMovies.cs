using System.Collections.Generic;

namespace MovieMiderm.Interfaces
{
    public interface ISearchForMovies
    {
        IList<IMovie> SearchByMovieName(string movieName, IList<IMovie> movies);
        IList<IMovie> SearchByActorName(string actorName, IList<IMovie> movies);
        IList<IMovie> SearchByGenre(string genre, IList<IMovie> movies);
        IList<IMovie> SearchByDirector(string director, IList<IMovie> movies);
    }
}