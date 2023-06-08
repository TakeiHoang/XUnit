using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultilities.Model
{
    public class AccountResultModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
