using System.Xml.Serialization;

namespace CarDealer.Models.ImportDTOs
{
    [XmlType("partId")]
    public class PartCarImportDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
