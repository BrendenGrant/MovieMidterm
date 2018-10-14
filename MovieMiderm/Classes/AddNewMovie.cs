using MovieMiderm.Interfaces;
using System.Collections.Generic;

namespace MovieMiderm.Classes
{
    public class AddNewMovie : IAddNewMovie
    {
        public void Add(IList<IMovie> movies, string movieName, string actorName, string genre, string director)
        {
            movies.Add(new Movie(movieName, actorName, genre, director));

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:/Users/Brenden/source/repos/MovieMiderm/MovieMiderm/MoviesList.txt", true))
            {
                file.WriteLine();
                file.Write($"{movieName},{actorName},{genre},{director}");
            }
        }
    }
}