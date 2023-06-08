using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace User
{
    public class UserModel
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }
        [JsonProperty("job")]
        [Required]
        public string Job { get; set; }
    }
}
