using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Account
{
    public class AccountModel
    {
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }
        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}
