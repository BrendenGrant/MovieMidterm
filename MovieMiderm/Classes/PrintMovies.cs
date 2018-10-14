using System;
using System.Collections.Generic;
using System.Text;
using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class PrintMovies
    {
        private static int _maxMovieNameLength;
        private static int _maxMainActorNameLength;
        private static int _maxGenreLength;
        private static int _maxDirectorLength;

        public static void Print(IList<IMovie> movies)
        {
            var currentRecordIndex = 0;

            GetLongestStringFromMovieList(movies);
            PrintHeaders();

            foreach (var movie in movies)
            {
                var movieToPrint = MoviePrintFormatting(movie, currentRecordIndex);
                Console.WriteLine(movieToPrint);
                currentRecordIndex++;
            }
        }

        private static string MoviePrintFormatting(IMovie movie, int currentRecordIndex)
        {
            return $"{currentRecordIndex, 2} " +
                $"{movie.MovieName.PadLeft(_maxMovieNameLength)} " +
                $"{movie.MainActorName.PadLeft(_maxMainActorNameLength)} " +
                $"{movie.Genre.PadLeft(_maxGenreLength)} " +
                $"{movie.Director.PadLeft(_maxDirectorLength)}";
        }

        private static void GetLongestStringFromMovieList(IList<IMovie> movies)
        {
            var getMaxStringLengths = new GetMaxStringLengths();

            _maxMovieNameLength = getMaxStringLengths.GetMaxMovieNameLength(movies);
            _maxMainActorNameLength = getMaxStringLengths.GetMaxMainActorNameLength(movies);
            _maxGenreLength = getMaxStringLengths.GetMaxGenreLength(movies);
            _maxDirectorLength = getMaxStringLengths.GetMaxDirectorLength(movies);
        }

        private static void PrintHeaders()
        {
            Console.WriteLine($"Movie Name".PadLeft(_maxMovieNameLength + 3) +
                            $"Main Actor".PadLeft(_maxMainActorNameLength + 1) +
                            $"Genre".PadLeft(_maxGenreLength + 1) +
                            $"Director".PadLeft(_maxDirectorLength + 1));

            var totalSpaces = 6 + _maxMovieNameLength + _maxMainActorNameLength + _maxGenreLength + _maxDirectorLength;
            var headerSeparator = new StringBuilder().Insert(0, "-", totalSpaces).ToString();

            Console.WriteLine(headerSeparator);
        }
    }
}