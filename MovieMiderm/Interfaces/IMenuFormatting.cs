using System.Collections.Generic;

namespace MovieMiderm.Interfaces
{
    public interface IMenuFormatting
    {
        IDictionary<string, string> MainMenuDisplay { get; }
        IEnumerable<string> MenuHeader { get; }
        IDictionary<string, string> SearchMenu { get; }
        IDictionary<string, IDictionary<string, string>> MenusDictionary { get; }
    }
}