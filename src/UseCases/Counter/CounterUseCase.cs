using Marimo.ABCDEApplicationTemplate.UseCases.Counter;
using System.Threading;
using System.Threading.Tasks;

namespace Marimo.ABCDEApplicationTemplate.Application.UseCases.Counter;

/// <summary>
/// カウンター操作用のユースケースです。
/// </summary>
/// <remarks>
/// 現時点ではテンプレートの最小実装として、
/// メモリ上のカウンター値を保持しながら増加処理を行います。
/// 今後のテスト追加にあわせて、ドメイン層やリポジトリへの委譲を検討します。
/// </remarks>
public sealed class CounterUseCase : ICounterUseCase
{
    int _value;

    /// <inheritdoc />
    public Task<CounterState> GetAsync(CancellationToken cancellationToken = default)
    {
        var state = new CounterState(_value);
        return Task.FromResult(state);
    }

    /// <inheritdoc />
    public Task<CounterState> IncrementAsync(CancellationToken cancellationToken = default)
    {
        _value++;
        var state = new CounterState(_value);
        return Task.FromResult(state);
    }
}
