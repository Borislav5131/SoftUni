namespace ProductShop.DTOS.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductsExportDto
    {
        public int Count { get; set; }

        public List<ProductExportDto> Products { get; set; }
    }
}
