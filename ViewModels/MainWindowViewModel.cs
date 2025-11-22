using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Marimo.ABCDEApplicationTemplate.ViewModels
{
    /// <summary>
    /// MainWindow 用のカウンター ViewModel です。
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// 現在のカウント値を取得します。
        /// </summary>
        [ObservableProperty]
        int _count;

        [RelayCommand]
        void Increment()
        {
            Count++;
        }
    }
}
