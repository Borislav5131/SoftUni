using System.Xml.Serialization;

namespace CarDealer.Models.ExportDTOs
{
    [XmlType("car")]
    public class ExportCarsWithMakeBMWDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
