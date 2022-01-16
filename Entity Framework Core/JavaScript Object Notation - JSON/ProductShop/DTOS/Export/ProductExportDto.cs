namespace ProductShop.DTOS.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductExportDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Seller { get; set; }
    }
}
