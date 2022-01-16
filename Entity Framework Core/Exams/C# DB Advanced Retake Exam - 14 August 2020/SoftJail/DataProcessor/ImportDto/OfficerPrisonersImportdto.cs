using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class OfficerPrisonersImportdto
    {
        [XmlAttribute("id")]
        [Required]
        public int Id { get; set; }
    }
}
