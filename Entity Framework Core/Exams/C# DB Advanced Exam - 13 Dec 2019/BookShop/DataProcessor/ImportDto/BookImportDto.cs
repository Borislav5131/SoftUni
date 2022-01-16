using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookImportDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Range(1,3)]
        [Required]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Range(0.01, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        [Range(50, 5000)]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}
