using Fusillade;
using ModernHttpClient;
using Planner.Abstractions.API;
using Refit;
using System;
using System.Net.Http;

namespace Planner.Services.API
{
    public class ApiService<T> : IApiService<T>
    {
        public ApiService(string apiBaseAddress)
        {
            T createClient(HttpMessageHandler messageHandler)
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress)
                };

                return RestService.For<T>(client);
            }

            _background = new Lazy<T>(() => createClient(
                new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background)));

            _userInitiated = new Lazy<T>(() => createClient(
                new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));

            _speculative = new Lazy<T>(() => createClient(
                new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative)));
        }

        private readonly Lazy<T> _background;
        private readonly Lazy<T> _userInitiated;
        private readonly Lazy<T> _speculative;

        public T Background
        {
            get { return _background.Value; }
        }

        public T UserInitiated
        {
            get { return _userInitiated.Value; }
        }

        public T Speculative
        {
            get { return _speculative.Value; }
        }
    }
}
