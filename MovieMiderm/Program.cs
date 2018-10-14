using MovieMiderm.Classes;
using MovieMiderm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMiderm
{
    public class Program
    {
        private static IList<IMovie> _movies;
        private static IInputValidation _inputValidation;
        private static ISearchForMovies _searchForMovies;
        private static IAddNewMovie _addNewMovie;

        static void Main(string[] args)
        {
            _movies = new List<IMovie>();
            _movies = GetMoviesFromTextFile.GetMovies();

            _inputValidation = new InputValidation();
            _searchForMovies = new SearchForMovies();
            _addNewMovie = new AddNewMovie();

            var menu = new Menus(_inputValidation, _searchForMovies, _addNewMovie, _movies);

            menu.PrintMainMenu();
        }
    }
}