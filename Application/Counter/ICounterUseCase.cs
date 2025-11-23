namespace Marimo.ABCDEApplicationTemplate.Application.Counter;

public interface ICounterUseCase
{
    Task<int> GetAsync(CancellationToken cancellationToken = default);
    Task<int> IncrementAsync(CancellationToken cancellationToken = default);
}
