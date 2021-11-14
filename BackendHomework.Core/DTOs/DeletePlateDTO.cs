using Newtonsoft.Json;
using System;

namespace BackendHomework.Core.DTOs
{
    public class DeletePlateDTO
    {
        [JsonProperty("plateId")]
        public Guid PlateId { get; set; }
    }
}
