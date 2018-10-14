namespace MovieMiderm.Interfaces
{
    public interface IMovie
    {
        string MovieName { get; }
        string MainActorName { get; }
        string Genre { get; }
        string Director { get; }
    }
}