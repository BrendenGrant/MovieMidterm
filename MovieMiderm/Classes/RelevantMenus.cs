using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class RelevantMenus : IRelevantMenus
    {
        private string _currentMenu;
        public string CurrentMenu
        {
            get { return _currentMenu; }
            set
            {
                if (_currentMenu == value)
                    return;

                _currentMenu = value;
            }
        }

        private string _nextMenu;
        public string NextMenu
        {
            get { return _nextMenu; }
            set
            {
                if (_nextMenu == value)
                    return;

                _nextMenu = value;
            }
        }
    }
}