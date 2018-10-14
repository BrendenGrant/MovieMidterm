using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMiderm.Interfaces
{
    public interface IInputValidation
    {
        bool IsValidMenuSelection(string menuSelection, IEnumerable<string> menuOptions);
        void InputValidationErrorMessage();
    }
}