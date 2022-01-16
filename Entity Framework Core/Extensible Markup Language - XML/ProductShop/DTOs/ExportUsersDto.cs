using System.Xml.Serialization;
using ProductShop.DTOs.Export;

namespace ProductShop.DTOs
{
    [XmlType("Users")]
    public class ExportUsersDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public ExportUserDto[] UsersDto { get; set; }
    }
}
