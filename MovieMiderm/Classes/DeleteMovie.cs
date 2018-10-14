using MovieMiderm.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieMiderm.Classes
{
    public class DeleteMovie : IDeleteMovie
    {
        public void Delete(IList<IMovie> movies, int indexToDelete)
        {
            var currentIndex = 0;

            movies.RemoveAt(indexToDelete);

            FileStream overwrite = File.Open(@"C:/Users/Brenden/source/repos/MovieMiderm/MovieMiderm/MoviesList.txt", FileMode.Create);
            overwrite.Close();

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:/Users/Brenden/source/repos/MovieMiderm/MovieMiderm/MoviesList.txt", true))
            {
                foreach (var movie in movies)
                {
                    if (currentIndex < movies.Count())
                        file.WriteLine($"{movie.MovieName},{movie.ActorName},{movie.Genre},{movie.Director}");
                    else
                        file.Write($"{movie.MovieName},{movie.ActorName},{movie.Genre},{movie.Director}");
                }
            }
        }
    }
}