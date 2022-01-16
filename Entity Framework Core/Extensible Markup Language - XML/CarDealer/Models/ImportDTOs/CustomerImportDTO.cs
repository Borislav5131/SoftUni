﻿using System;
using System.Xml.Serialization;

namespace CarDealer.Models.ImportDTOs
{
    [XmlType("Customer")]
    public class CustomerImportDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }
        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
