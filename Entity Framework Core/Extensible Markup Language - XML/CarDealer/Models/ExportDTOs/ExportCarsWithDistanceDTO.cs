using System.Xml.Serialization;

namespace CarDealer.Models.ExportDTOs
{
    [XmlType("car")]
    public class ExportCarsWithDistanceDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
