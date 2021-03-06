using System.Xml.Serialization;

namespace CarDealer.Models.ExportDTOs
{
    [XmlType("part")]
    public class ExportCarPartDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
