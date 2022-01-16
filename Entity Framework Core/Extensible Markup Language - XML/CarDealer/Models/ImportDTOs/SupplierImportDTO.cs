using System.Xml.Serialization;

namespace CarDealer.Models.ImportDTOs
{
    [XmlType("Supplier")]
    public class SupplierImportDTO
    {
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public bool IsImporter { get; set; }
    }
}
