using Plugin.Connectivity;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Abstractions
{
    public abstract class ApiServiceBase
    {
        private readonly ICancellationTokenResolver _cancellationTokenResolver;

        protected ApiServiceBase(ICancellationTokenResolver cancellationTokenResolver)
        {
            _cancellationTokenResolver = cancellationTokenResolver;
        }

        protected async Task<T> MakeApiCallAsync<T>(Func<Task<T>> func)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                //custom "not connected" exception
                throw new Exception();
            }

            return await Policy
                .Handle<WebException>()
                .Or<HttpRequestException>()
                .WaitAndRetryAsync
                (
                    retryCount: 5,
                    sleepDurationProvider: x => TimeSpan.FromMilliseconds(300)
                )
                .ExecuteAsync(func /*cancellationToken*/);
            
        }
    }
}
