using FluentAssertions;
using Marimo.ABCDEApplicationTemplate.Domain;
using Xunit;

namespace Marimo.ABCDEApplicationTemplate.Domain.Tests.CounterFeature;

public class CounterTests
{
    [Fact]
    public void 初期値0のカウンターを生成できます()
    {
        // Act
        var actual = new Counter(0);

        // Assert
        actual.Value.Should().Be(0);
    }

    [Fact]
    public void カウンターを1回増やすと1のカウンターが返されます()
    {
        // Arrange
        var counter = new Counter(0);

        // Act
        var actual = counter.Increment();

        // Assert
        actual.Value.Should().Be(1);
    }
}
