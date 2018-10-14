using System.Collections.Generic;

namespace MovieMiderm.Interfaces
{
    public interface IInputValidation
    {
        bool IsValidMenuSelection(string menuSelection, IEnumerable<string> menuOptions);
        bool IsValidSelectionForDelete(string userInput, IList<IMovie> movies);
        void InputValidationErrorMessage();
    }
}