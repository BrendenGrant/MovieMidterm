using System.Collections.Generic;
using System.Linq;
using MovieMiderm.Interfaces;

namespace MovieMiderm.Classes
{
    public class InputValidation : IInputValidation
    {
        public bool IsValidMenuSelection(string menuSelection, IEnumerable<string> menuOptions)
        {
            if (!int.TryParse(menuSelection, out int intSelection))
                return false;

            return (intSelection > 0 && intSelection <= menuOptions.Count());
        }

        public bool IsValidSelectionForDelete(string userInput, IList<IMovie> movies)
        {
            if (!int.TryParse(userInput, out int intSelection))
                return false;

            return (intSelection > 0 && intSelection <= movies.Count());
        }

        public void InputValidationErrorMessage()
        {
            System.Console.WriteLine("Selection was invalid. Please enter a valid choice.");
        }
    }
}