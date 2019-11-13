using System.Threading;

namespace Planner.Abstractions
{
    public interface ICancellationTokenResolver
    {
        CancellationToken GetCancellationToken();
    }
}
