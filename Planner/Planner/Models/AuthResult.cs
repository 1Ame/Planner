using Newtonsoft.Json;

namespace Planner.Models
{
    public class AuthResult
    {
        [JsonProperty("authenticated")]
        public bool IsAuthenticated { get; set; }

        [JsonProperty("user")]
        public string Login { get; set; }
    }
}
