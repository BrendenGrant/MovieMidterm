using System;
using System.Collections.Generic;
using System.Linq;
using MovieMiderm.Interfaces;
using static MovieMiderm.Constants.Constants;

namespace MovieMiderm.Classes
{
    public class MenuNavigation
    {
        private IList<IMovie> _movies;

        private IInputValidation _inputValidation;
        private IMenuFormatting _menuFormatting;
        private IMenuCommands _menuCommands;
        private IRelevantMenus _relevantMenus;
        
        private string _userInput;

        public MenuNavigation(IInputValidation inputValidation, IMenuFormatting menuFormatting, IList<IMovie> movies, IRelevantMenus relevantMenus)
        {
            _inputValidation = inputValidation;
            _menuFormatting = menuFormatting;
            _movies = movies;
            _relevantMenus = relevantMenus;
            _relevantMenus.CurrentMenu = MenuTypeCodes.MAIN_MENU;
            _menuCommands = new MenuCommands(_menuFormatting, new AddNewMovie(), new DeleteMovie(), new SearchForMovies(), _inputValidation, _movies, _relevantMenus);
            _menuCommands.PrintCurrentMenu();
            HandleMenuSelection();
        }

        private void HandleMenuSelection()
        {
            _userInput = Console.ReadLine();
            var currentMenuList = _menuFormatting.MenusDictionary.Where(x => x.Key == _relevantMenus.CurrentMenu).Select(y => y.Value).SingleOrDefault().Values.ToList();

            if (!_inputValidation.IsValidMenuSelection(_userInput, currentMenuList) && _relevantMenus.CurrentMenu != MenuTypeCodes.DELETE_MOVIE)
            {
                _menuCommands.IsUserInputValid = false;
                _menuCommands.ClearScreen();
                _menuCommands.PrintCurrentMenu();
            }
            else
            {
                var userInputInt = Convert.ToInt32(_userInput) - 1;

                _relevantMenus.NextMenu = _menuFormatting.MenusDictionary[_relevantMenus.CurrentMenu].Keys.ElementAt(userInputInt);
                _menuCommands.ClearScreen();
                _menuCommands.PrintNextMenu();
            }

            if (_relevantMenus.NextMenu == MenuTypeCodes.QUIT)
                return;

            if (_relevantMenus.CurrentMenu == MenuTypeCodes.MAIN_MENU || _relevantMenus.CurrentMenu == MenuTypeCodes.SEARCH_MENU)
                HandleMenuSelection();
        }
    }
}