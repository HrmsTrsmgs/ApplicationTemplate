using Marimo.ABCDEApplicationTemplate.ViewModels;
using Microsoft.UI.Xaml;

namespace Marimo.ABCDEApplicationTemplate;

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
