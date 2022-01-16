using System.Collections.Generic;
using CarDealer.Models;

namespace CarDealer.DTO.Export
{
    public class CarWithPartsExportDTO
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public IEnumerable<PartsExportDTO> Parts { get; set; }
    }
}
