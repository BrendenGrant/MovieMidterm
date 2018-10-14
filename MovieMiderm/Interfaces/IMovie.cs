namespace MovieMiderm.Interfaces
{
    public interface IMovie
    {
        string MovieName { get; }
        string ActorName { get; }
        string Genre { get; }
        string Director { get; }
    }
}