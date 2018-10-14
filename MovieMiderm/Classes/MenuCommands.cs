using System;
using System.Collections.Generic;
using System.Linq;
using MovieMiderm.Interfaces;
using static MovieMiderm.Constants.Constants;

namespace MovieMiderm.Classes
{
    public class MenuCommands : IMenuCommands
    {
        private IDictionary<string, Action> _menusToPrint;
        private IList<IMovie> _searchedMovieResults;
        private IList<IMovie> _movies;
        private IMenuFormatting _menuFormatting;
        private IAddNewMovie _addNewMovie;
        private ISearchForMovies _searchForMovies;
        private IInputValidation _inputValidation;
        private IRelevantMenus _relevantMenus;
        private Action _printMainMenuAction;
        private Action _printMoviesAction;
        private Action _printSearchMenuAction;
        private Action _searchMovieNameAction;
        private Action _searchActorNameAction;
        private Action _searchGenreAction;
        private Action _searchDirectorAction;
        private Action _addNewMovieAction;
        private Action _quit;

        private bool _isUserInputValid = true;
        public bool IsUserInputValid
        {
            get { return _isUserInputValid; }
            set
            {
                if (_isUserInputValid == value)
                    return;

                _isUserInputValid = value;
            }
        }

        public MenuCommands(IMenuFormatting menuFormatting, IAddNewMovie addNewMovie, ISearchForMovies searchForMovies, IInputValidation inputValidation, IList<IMovie> movies, IRelevantMenus relevantMenus)
        {
            _menuFormatting = menuFormatting;
            _addNewMovie = addNewMovie;
            _searchForMovies = searchForMovies;
            _inputValidation = inputValidation;
            _movies = movies;
            _relevantMenus = relevantMenus;
            _menusToPrint = new Dictionary<string, Action>();
            _searchedMovieResults = new List<IMovie>();
            SetUpDelegates();
            GenerateMenusToPrint();
        }

        private void SetUpDelegates()
        {
            _printMainMenuAction = delegate () { PrintMainMenu(); };
            _printMoviesAction = delegate () { PrintAllMovies(); };
            _printSearchMenuAction = delegate () { PrintSearchMenu(); };
            _searchMovieNameAction = delegate () { SearchByMovieNameMenu(); };
            _searchActorNameAction = delegate () { SearchByActorNameMenu(); };
            _searchGenreAction = delegate () { SearchByGenreMenu(); };
            _searchDirectorAction = delegate () { SearchByDirectorMenu(); };
            _addNewMovieAction = delegate () { AddNewMovieMenu(); };
            _quit = delegate () { Quit(); };
        }

        private void GenerateMenusToPrint()
        {
            _menusToPrint.Add(MenuTypeCodes.MAIN_MENU, _printMainMenuAction);
            _menusToPrint.Add(MenuTypeCodes.PRINT_MOVIES, _printMoviesAction);
            _menusToPrint.Add(MenuTypeCodes.SEARCH_MENU, _printSearchMenuAction);
            _menusToPrint.Add(MenuTypeCodes.QUIT, _quit);
            _menusToPrint.Add(MenuTypeCodes.SEARCH_MOVIE_NAME, _searchMovieNameAction);
            _menusToPrint.Add(MenuTypeCodes.SEARCH_ACTOR_NAME, _searchActorNameAction);
            _menusToPrint.Add(MenuTypeCodes.SEARCH_GENRE, _searchGenreAction);
            _menusToPrint.Add(MenuTypeCodes.SEARCH_DIRECTOR, _searchDirectorAction);
            _menusToPrint.Add(MenuTypeCodes.ADD_NEW_MOVIE, _addNewMovieAction);
        }

        public void PrintCurrentMenu()
        {
            _menusToPrint[_relevantMenus.CurrentMenu].Invoke();
        }

        public void PrintNextMenu()
        {
            _menusToPrint[_relevantMenus.NextMenu].Invoke();
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        private void PrintSearchedMovies(IList<IMovie> searchedMovieResults)
        {
            Console.WriteLine();
            PrintMovies.Print(searchedMovieResults);
            Console.WriteLine();
        }

        private void PrintMenuHeader()
        {
            if (!IsUserInputValid)
                _inputValidation.InputValidationErrorMessage();

            foreach (var item in _menuFormatting.MenuHeader)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintMainMenu()
        {
            PrintMenuHeader();

            foreach (var item in _menuFormatting.MainMenuDisplay)
            {
                Console.WriteLine(item.Value);
            }

            _relevantMenus.CurrentMenu = MenuTypeCodes.MAIN_MENU;
        }

        private void PrintAllMovies()
        {
            PrintMovies.Print(_movies);
            Console.WriteLine();
            PrintMainMenu();
        }

        private void PrintSearchMenu()
        {
            PrintMenuHeader();

            foreach (var item in _menuFormatting.SearchMenu)
            {
                Console.WriteLine(item.Value);
            }

            _relevantMenus.CurrentMenu = MenuTypeCodes.SEARCH_MENU;
        }

        private void SearchByMovieNameMenu()
        {
            Console.Write("Enter the full or partial movie name you want to search for: ");
            var movieName = Console.ReadLine();

            _searchedMovieResults.Clear();
            _searchedMovieResults = _searchForMovies.SearchByMovieName(movieName, _movies);
            PrintSearchedResults();
        }

        private void SearchByActorNameMenu()
        {
            Console.Write("Enter the full or partial actor name you want to search for: ");
            var actorName = Console.ReadLine();

            _searchedMovieResults.Clear();
            _searchedMovieResults = _searchForMovies.SearchByActorName(actorName, _movies);
            PrintSearchedResults();
        }

        private void SearchByGenreMenu()
        {
            Console.Write("Enter the full or partial genre name you want to search for: ");
            var genre = Console.ReadLine();

            _searchedMovieResults.Clear();
            _searchedMovieResults = _searchForMovies.SearchByGenre(genre, _movies);
            PrintSearchedResults();
        }

        private void SearchByDirectorMenu()
        {
            Console.Write("Enter the full or partial director name you want to search for: ");
            var director = Console.ReadLine();

            _searchedMovieResults.Clear();
            _searchedMovieResults = _searchForMovies.SearchByDirector(director, _movies);
            PrintSearchedResults();
        }

        private void PrintSearchedResults()
        {
            IsUserInputValid = true;

            if (!_searchedMovieResults.Any())
                NoResultsFound();
            else
                PrintSearchedMovies(_searchedMovieResults);

            Console.WriteLine();
            PrintCurrentMenu();
        }

        private void AddNewMovieMenu()
        {
            string newMovieName;
            string newActorName;
            string newGenre;
            string newDirector;

            Console.Write("Enter the name of the movie: ");
            newMovieName = Console.ReadLine();

            Console.Write("Enter the main actor's name: ");
            newActorName = Console.ReadLine();

            Console.Write("Enter the genre of the movie: ");
            newGenre = Console.ReadLine();

            Console.Write("Enter the name of the director: ");
            newDirector = Console.ReadLine();

            _addNewMovie.Add(_movies, newMovieName, newActorName, newGenre, newDirector);
            Console.WriteLine();
            PrintCurrentMenu();
        }

        private void Quit() { }

        private void NoResultsFound()
        {
            Console.WriteLine("There are no movies matching that criteria. Please try again.");
        }
    }
}