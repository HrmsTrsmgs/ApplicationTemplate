using FluentAssertions;
using Xunit;
using Marimo.ABCDEApplicationTemplate.ViewModels;

namespace Marimo.ABCDEApplicationTemplate.ViewModels.Tests;

public class MainWindowViewModelTests
{
    [Fact]
    public void カウントの初期値は0です()
    {
        // Arrange
        var viewModel = new MainWindowViewModel();

        // Act
        var count = viewModel.Count;

        // Assert
        count.Should().Be(0);
    }
}
