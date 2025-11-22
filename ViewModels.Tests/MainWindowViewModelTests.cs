using FluentAssertions;
using Xunit;
using Marimo.ABCDEApplicationTemplate.ViewModels;
using Marimo.ABCDEApplicationTemplate.ViewModels.Tests.Share;

namespace Marimo.ABCDEApplicationTemplate.ViewModels.Tests;

public class MainWindowViewModelTests
{
    MainWindowViewModel Target { get; } = new();

    [Fact]
    public void カウントの初期値は0です()
    {
        // Assert
        Target.Count.Should().Be(0);
    }

    [Fact]
    public void カウントを1回増やすと1になります()
    {
        // Act
        Target.IncrementCommand.Execute();

        // Assert
        Target.Count.Should().Be(1);
    }

    [Fact]
    public void カウントが変更されると変更通知が行われます()
    {
        string? propertyName = null;

        Target.PropertyChanged += (_, e) =>
        {
            propertyName = e.PropertyName;
        };

        // Act
        Target.IncrementCommand.Execute();

        // Assert
        propertyName.Should().Be(nameof(MainWindowViewModel.Count));
    }

}

