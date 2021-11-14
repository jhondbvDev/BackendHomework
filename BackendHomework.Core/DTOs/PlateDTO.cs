using Newtonsoft.Json;

namespace BackendHomework.Core.DTOs
{
    public class PlateDTO : CreatePlateDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
