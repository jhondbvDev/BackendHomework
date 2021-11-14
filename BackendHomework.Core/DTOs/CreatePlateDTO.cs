using Newtonsoft.Json;

namespace BackendHomework.Core.DTOs
{
    public class CreatePlateDTO
    {
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
