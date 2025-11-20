using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ABCDEApplicationTemplate
{
    /// <summary>
    /// カウンター付きのメインウィンドウです。
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private int _count = 0;

        public MainWindow()
        {
            InitializeComponent();
            UpdateCounterText();
        }

        private void IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            UpdateCounterText();
        }

        private void UpdateCounterText()
        {
            CounterTextBlock.Text = _count.ToString();
        }
    }
}
