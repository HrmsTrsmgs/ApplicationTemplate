using System.Windows.Input;

namespace Marimo.ABCDEApplicationTemplate.ViewModels.Tests.Share;

public static class CommandExtensions
{
    public static void Execute(this ICommand self)
    {
        self.Execute(null);
    }
}
