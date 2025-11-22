using Marimo.ABCDEApplicationTemplate.ViewModels;
using Microsoft.UI.Xaml;

namespace Marimo.ABCDEApplicationTemplate;

public sealed partial class MainWindow : Window
{
    /// <summary>
    /// MainWindow —p‚Ì ViewModel ‚ğæ“¾‚µ‚Ü‚·B
    /// </summary>
    public MainWindowViewModel ViewModel { get; } = new();

    public MainWindow()
    {
        InitializeComponent();
    }
}
