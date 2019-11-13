using Fusillade;
using Planner.Abstractions;
using Planner.Abstractions.API;
using Planner.Models;
using Planner.Services.API;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class ExampleService : ApiServiceBase, IExampleService
    {
        public readonly IApiService<IApiExampleService> _exampleApiService;

        public ExampleService():base(null)
        {
            _exampleApiService = new ApiService<IApiExampleService>("<base url>");
        }

        public async Task<AuthResult> BasicAuth(string username, string password, Priority priority = Priority.Background)
        {
            var apiCall = _exampleApiService.GetService(priority).BasicAuth(username, password, null, default(CancellationToken));

            return await MakeApiCallAsync(() => _exampleApiService.GetService(priority).BasicAuth(username, password, null, default(CancellationToken)));
        }
    }
}
