using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.Models.ImportDTOs
{
    [XmlType("Car")]
    public class CarImportDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public PartCarImportDTO[] PartCars { get; set; }
    }
}
