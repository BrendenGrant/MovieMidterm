using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class Movie : IMovie
    {
        public string MovieName { get; private set; }
        public string MainActorName { get; private set; }
        public string Genre { get; private set; }
        public string Director { get; private set; }

        public Movie(string movieName, string mainActorName, string genre, string director)
        {
            MovieName = movieName;
            MainActorName = mainActorName;
            Genre = genre;
            Director = director;
        }
    }
}