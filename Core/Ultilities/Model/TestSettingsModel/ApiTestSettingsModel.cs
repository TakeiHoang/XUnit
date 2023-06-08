using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultilities.Model.TestSettingsModel
{
    public class ApiTestSettingsModel
    {
        [JsonProperty("baseUrl")]
        public required string BaseUrl { get; set; }
    }
}
