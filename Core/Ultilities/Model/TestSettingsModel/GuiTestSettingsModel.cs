using Newtonsoft.Json;

namespace Core.Ultilities.Model.TestSettingsModel
{
    public class GuiTestSettingsModel
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }
        [JsonProperty("account")]
        public Account Account { get; set; }
    }

    public class Account
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
