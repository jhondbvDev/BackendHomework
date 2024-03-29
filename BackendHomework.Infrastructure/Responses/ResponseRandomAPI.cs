﻿using Newtonsoft.Json;

namespace BackendHomework.Infrastructure.Responses
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
