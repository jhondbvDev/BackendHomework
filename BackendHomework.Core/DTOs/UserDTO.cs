using Newtonsoft.Json;

namespace BackendHomework.Core.DTOs
{
    public class UserDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
