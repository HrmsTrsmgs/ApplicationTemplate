using Marimo.ABCDEApplicationTemplate.Domain;
using System.Diagnostics.Metrics;
using System.Threading;
using System.Threading.Tasks;

namespace Marimo.ABCDEApplicationTemplate.Application.UseCases.CounterFeature;
/// <summary>
/// カウンター操作用のユースケースです。
/// </summary>
/// <remarks>
/// 現時点ではテンプレートの最小実装として、
/// ドメインの <see cref="Counter"/> をメモリ上に保持しながら増加処理を行います。
/// 今後のテスト追加にあわせて、リポジトリなどへの委譲を検討します。
/// </remarks>
public sealed class CounterUseCase
{
    Counter _counter = new(0);

    /// <summary>
    /// 現在のカウンター状態を取得します。
    /// </summary>
    public Task<CounterState> GetAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(ToState(_counter));

    /// <summary>
    /// カウント値を 1 増加させた状態を取得します。
    /// </summary>
    public Task<CounterState> IncrementAsync(CancellationToken cancellationToken = default)
    {
        _counter = _counter.Increment();
        return Task.FromResult(ToState(_counter));
    }

    static CounterState ToState(Counter counter) => new(counter.Value);
}
