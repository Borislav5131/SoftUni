﻿using System.Xml.Serialization;

namespace CarDealer.Models.ExportDTOs
{
    [XmlType("car")]
    public class ExportCarsWithTheirListOfPartsDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
        
        [XmlArray("parts")]
        public ExportCarPartDTO[] Parts { get; set; }
    }
}
