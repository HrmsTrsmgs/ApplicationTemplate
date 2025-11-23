using Marimo.ABCDEApplicationTemplate.Presentation.ViewModels;
using Microsoft.UI.Xaml;

namespace Marimo.ABCDEApplicationTemplate.Presentation;

public sealed partial class MainWindow : Window
{
    /// <summary>
    /// MainWindow 用の ViewModel を取得します。
    /// </summary>
    public MainWindowViewModel ViewModel { get; } = new();

    public MainWindow()
    {
        InitializeComponent();
    }
}
