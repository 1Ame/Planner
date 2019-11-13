using Fusillade;
using Planner.Models;
using System.Threading.Tasks;

namespace Planner.Abstractions
{
    public interface IExampleService
    {
        Task<AuthResult> BasicAuth(string username, string password, Priority priority = Priority.Background);
    }
}
