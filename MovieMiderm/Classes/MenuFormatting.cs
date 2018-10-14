using System.Collections.Generic;
using MovieMiderm.Interfaces;
using static MovieMiderm.Constants.Constants;

namespace MovieMiderm.Classes
{
    public class MenuFormatting : IMenuFormatting
    {
        public IEnumerable<string> MenuHeader { get; private set; }
        public IDictionary<string, string> MainMenuDisplay { get; private set; }
        public IDictionary<string, string> SearchMenu { get; private set; }
        public IDictionary<string, IDictionary<string, string>> MenusDictionary { get; private set; }

        public MenuFormatting()
        {
            MenusDictionary = new Dictionary<string, IDictionary<string, string>>();
            GenerateMenuHeader();
            GenerateMainMenu();
            GenerateSearchMenu();
            GenerateMenusDictionary();
        }

        private void GenerateMenuHeader()
        {
            MenuHeader = new List<string>
            {
                "Please select from the options below",
                "------------------------------------"
            };
        }

        private void GenerateMainMenu()
        {
            MainMenuDisplay = new Dictionary<string, string>
            {
                { MenuTypeCodes.PRINT_MOVIES, "1. Show movie list" },
                { MenuTypeCodes.SEARCH_MENU, "2. Search movie list" },
                { MenuTypeCodes.ADD_NEW_MOVIE, "3. Add new movie to list" },
                { MenuTypeCodes.QUIT, "4. Quit" }
            };
        }

        private void GenerateSearchMenu()
        {
            SearchMenu = new Dictionary<string, string>
            {
                { MenuTypeCodes.SEARCH_MOVIE_NAME, "1. Search by movie name" },
                { MenuTypeCodes.SEARCH_ACTOR_NAME, "2. Search by actor name" },
                { MenuTypeCodes.SEARCH_GENRE, "3. Search by genre" },
                { MenuTypeCodes.SEARCH_DIRECTOR, "4. Search by director" },
                { MenuTypeCodes.MAIN_MENU, "5. Main menu" }
            };
        }

        private void GenerateMenusDictionary()
        {
            MenusDictionary.Add(MenuTypeCodes.MAIN_MENU, MainMenuDisplay);
            MenusDictionary.Add(MenuTypeCodes.SEARCH_MENU, SearchMenu);
        }
    }
}