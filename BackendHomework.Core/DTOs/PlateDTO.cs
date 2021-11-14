using Newtonsoft.Json;

namespace BackendHomework.Core.DTOs
{
    public class PlateDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
