using Newtonsoft.Json;

namespace ListResources
{
    public class ListResourcesModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int Per_page { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int Total_pages { get; set; }
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
        [JsonProperty("support")]
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
