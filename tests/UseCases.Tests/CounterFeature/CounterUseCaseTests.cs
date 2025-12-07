using FluentAssertions;
using Marimo.ABCDEApplicationTemplate.Application.UseCases.CounterFeature;

namespace Marimo.ABCDEApplicationTemplate.Application.UseCases.Tests.CounterFeature;

public class CounterUseCaseTests
{
    CounterUseCase Target { get; } = new();

    [Fact]
    public async Task 初期状態を取得すると0が返されます()
    {
        // Act
        var actual = await Target.GetAsync(CancellationToken.None);

        // Assert
        actual.Value.Should().Be(0);
    }

    [Fact]
    public async Task カウントを1回増やすと1が返されます()
    {
        // Act
        var actual = await Target.IncrementAsync(CancellationToken.None);

        // Assert
        actual.Value.Should().Be(1);
    }
}
