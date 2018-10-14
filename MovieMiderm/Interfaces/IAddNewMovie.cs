using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMiderm.Interfaces
{
    public interface IAddNewMovie
    {
        void Add(IList<IMovie> movies, string movieName, string actorName, string genre, string director);
    }
}