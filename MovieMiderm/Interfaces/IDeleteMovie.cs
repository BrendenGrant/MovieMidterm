using System.Collections.Generic;

namespace MovieMiderm.Interfaces
{
    public interface IDeleteMovie
    {
        void Delete(IList<IMovie> movies, int indexToDelete);
    }
}