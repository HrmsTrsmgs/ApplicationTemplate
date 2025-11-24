namespace Marimo.ABCDEApplicationTemplate.UseCases.Counter;

public interface ICounterUseCase
{
    Task<CounterState> GetAsync(CancellationToken cancellationToken = default);
}
