namespace Planner.Abstractions.API
{
    public interface IApiService<T>
    {
        T Background { get; }
        T UserInitiated { get; }
        T Speculative { get; }
    }
}
