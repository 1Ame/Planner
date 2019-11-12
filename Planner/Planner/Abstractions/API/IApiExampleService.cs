using Planner.Models;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Planner.Abstractions.API
{
    [Headers("Accept: application/json")]
    public interface IApiExampleService
    {
        [Get("/basic-auth/{username}/{password}")]
        Task<AuthResult> BasicAuth(string username, string password, [Header("Authorization")] string authToken, CancellationToken cancellationToken);
    }
}
