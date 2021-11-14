using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendHomework.Core.DTOs
{
    public class PlateDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
