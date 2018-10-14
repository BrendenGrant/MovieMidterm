using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class Movie : IMovie
    {
        public string MovieName { get; private set; }
        public string ActorName { get; private set; }
        public string Genre { get; private set; }
        public string Director { get; private set; }

        public Movie(string movieName, string actorName, string genre, string director)
        {
            MovieName = movieName;
            ActorName = actorName;
            Genre = genre;
            Director = director;
        }
    }
}