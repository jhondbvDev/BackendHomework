using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.API.Response
{
    public class ResponseRandomAPI
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("min")]
        public int Min { get; set; }
        [JsonProperty("max")]
        public int Max { get; set; }
        [JsonProperty("random")]
        public int Random { get; set; }
    }
}
