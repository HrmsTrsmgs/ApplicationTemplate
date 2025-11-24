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
public sealed class CounterUseCase
{
    int _value;

    /// <summary>
    /// 現在のカウンター状態を取得します。
    /// </summary>
    public Task<CounterState> GetAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(new CounterState(_value));

    /// <summary>
    /// カウント値を 1 増加させた状態を取得します。
    /// </summary>
    public Task<CounterState> IncrementAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(new CounterState(++_value));
}
