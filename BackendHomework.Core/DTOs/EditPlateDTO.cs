using Newtonsoft.Json;
using System;

namespace BackendHomework.Core.DTOs
{
    public class EditPlateDTO 
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
