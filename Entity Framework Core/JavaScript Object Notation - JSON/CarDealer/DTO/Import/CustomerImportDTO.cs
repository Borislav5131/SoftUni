namespace CarDealer.DTO.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomerImportDTO
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
