using MovieMiderm.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public void InputValidationErrorMessage()
        {
            System.Console.WriteLine("Selection was invalid. Please enter a valid choice.");
        }
    }
}