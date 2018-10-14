using MovieMiderm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MovieMiderm.Constants.Constants;

namespace MovieMiderm.Classes
{
    public class Menus
    {
        private IDictionary<string, Action> _menusToPrint;
        private IDictionary<string, IDictionary<string, string>> _menusDictionary;
        private IDictionary<string, string> _mainMenuDisplay;
        private IDictionary<string, string> _searchMenu;
        private IEnumerable<string> _menuHeader;
        private IList<IMovie> _movies;
        private IList<IMovie> _searchedMovieResults;

        private Action _printMainMenuAction;
        private Action _printMoviesAction;
        private Action _printSearchMenuAction;
        private Action _searchMovieNameAction;
        private Action _searchActorNameAction;
        private Action _searchGenreAction;
        private Action _searchDirectorAction;
        private Action _addNewMovieAction;
        private Action _quit;
        private IInputValidation _inputValidation;
        private ISearchForMovies _searchForMovies;
        private IAddNewMovie _addNewMovie;

        private string _currentMenu;
        private string _nextMenu;
        private string _userInput;
        private bool _isUserInputValid = true;

        public Menus(IInputValidation inputValidation, ISearchForMovies searchForMovies,
                     IAddNewMovie addNewMovie, IList<IMovie> movies)
        {
            _inputValidation = inputValidation;
            _searchForMovies = searchForMovies;
            _addNewMovie = addNewMovie;
            _menusToPrint = new Dictionary<string, Action>();
            _searchedMovieResults = new List<IMovie>();
            _menusDictionary = new Dictionary<string, IDictionary<string, string>>();
            _currentMenu = MenuTypeCodes.MAIN_MENU;
            _movies = movies;

            SetUpDelegates();
            GenerateItems();
        }

        private void PrintMenuHeader()
        {
            if (!_isUserInputValid)
                _inputValidation.InputValidationErrorMessage();

            foreach (var item in _menuHeader)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintMainMenu()
        {
            PrintMenuHeader();

            foreach (var item in _mainMenuDisplay)
            {
                Console.WriteLine(item.Value);
            }

            _currentMenu = MenuTypeCodes.MAIN_MENU;
            HandleMenuSelection();
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

            foreach (var item in _searchMenu)
            {
                Console.WriteLine(item.Value);
            }

            _currentMenu = MenuTypeCodes.SEARCH_MENU;
            HandleMenuSelection();
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
            PrintCurrentMenu();
        }

        private void Quit() { }

        private void PrintSearchedMovies(IList<IMovie> searchedMovieResults)
        {
            PrintMovies.Print(searchedMovieResults);
            Console.WriteLine();
        }

        private void HandleMenuSelection()
        {
            _userInput = Console.ReadLine();
            var currentMenuList = _menusDictionary.Where(x => x.Key == _currentMenu).Select(y => y.Value).SingleOrDefault().Values.ToList();

            if (!_inputValidation.IsValidMenuSelection(_userInput, currentMenuList))
            {
                _isUserInputValid = false;
                ClearScreen();
                PrintCurrentMenu();
            }
            else
            {
                var userInputInt = Convert.ToInt32(_userInput) - 1;

                _nextMenu = _menusDictionary[_currentMenu].Keys.ElementAt(userInputInt);
                ClearScreen();
                PrintNextMenu();
            }
        }

        private void PrintCurrentMenu()
        {
            _menusToPrint[_currentMenu].Invoke();
        }

        private void PrintNextMenu()
        {
            _menusToPrint[_nextMenu].Invoke();
        }

        private void ClearScreen()
        {
            Console.Clear();
        }

        private void NoResultsFound()
        {
            Console.WriteLine("There are no movies matching that criteria. Please try again.");
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

        private void GenerateItems()
        {
            GenerateMenuHeader();
            GenerateMainMenu();
            GenerateSearchMenu();
            GenerateMenusToPrint();
            GenerateMenusDictionary();
        }

        private void GenerateMenuHeader()
        {
            _menuHeader = new List<string>
            {
                "Please select from the options below",
                "------------------------------------"
            };
        }

        private void GenerateMainMenu()
        {
            _mainMenuDisplay = new Dictionary<string, string>
            {
                { MenuTypeCodes.PRINT_MOVIES, "1. Show movie list" },
                { MenuTypeCodes.SEARCH_MENU, "2. Search movie list" },
                { MenuTypeCodes.ADD_NEW_MOVIE, "3. Add new movie to list" },
                { MenuTypeCodes.QUIT, "4. Quit" }
            };
        }

        private void GenerateSearchMenu()
        {
            _searchMenu = new Dictionary<string, string>
            {
                { MenuTypeCodes.SEARCH_MOVIE_NAME, "1. Search by movie name" },
                { MenuTypeCodes.SEARCH_ACTOR_NAME, "2. Search by actor name" },
                { MenuTypeCodes.SEARCH_GENRE, "3. Search by genre" },
                { MenuTypeCodes.SEARCH_DIRECTOR, "4. Search by director" },
                { MenuTypeCodes.MAIN_MENU, "5. Main menu" }
            };
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

        private void GenerateMenusDictionary()
        {
            _menusDictionary.Add(MenuTypeCodes.MAIN_MENU, _mainMenuDisplay);
            _menusDictionary.Add(MenuTypeCodes.SEARCH_MENU, _searchMenu);
        }
    }
}