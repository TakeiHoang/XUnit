using Newtonsoft.Json;

namespace Core.Ultilities.Model
{
    public class UserResultModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreateAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
