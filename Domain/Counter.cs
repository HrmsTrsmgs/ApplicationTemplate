// src/Domain/Counter.cs

namespace Marimo.ABCDEApplicationTemplate.Domain;

/// <summary>
/// カウンターの値を表す値オブジェクトです。
/// </summary>
public sealed record Counter(int Value)
{
/// <summary>
    /// カウンターの値を 1 増加させた新しいインスタンスを取得します。
    /// </summary>
    /// <returns>値が 1 増加したカウンター。</returns>
    public Counter Increment() => new(Value + 1);
}