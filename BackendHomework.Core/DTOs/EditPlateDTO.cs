using Newtonsoft.Json;

namespace BackendHomework.Core.DTOs
{
    public class EditPlateDTO : DeletePlateDTO
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
