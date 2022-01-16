using System.Xml.Serialization;

namespace CarDealer.Models.ExportDTOs
{
    [XmlType("customer")]
    public class ExportTotalSaleByCustomerDTO
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }
        [XmlAttribute(("bought-cars"))]
        public int BoughtCars { get; set; }
        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
