using Newtonsoft.Json;

namespace SingleResource
{
    public class SingleResourceModel
    {
        public Data Data { get; set; }
        public Support Support { get; set; }
    }
    public class Data
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("pantone_value")]
        public string Pantone_value { get; set; }
    }

    public class Support
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}