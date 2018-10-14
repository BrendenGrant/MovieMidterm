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
        private static IMenuFormatting _menuFormatting;
        private static IRelevantMenus _relevantMenus;

        static void Main(string[] args)
        {
            _movies = new List<IMovie>();
            _movies = GetMoviesFromTextFile.GetMovies();

            _inputValidation = new InputValidation();
            _searchForMovies = new SearchForMovies();
            _menuFormatting = new MenuFormatting();
            _relevantMenus = new RelevantMenus();

            var menuNavigation = new MenuNavigation(_inputValidation, _menuFormatting,  _movies, _relevantMenus);
        }
    }
}