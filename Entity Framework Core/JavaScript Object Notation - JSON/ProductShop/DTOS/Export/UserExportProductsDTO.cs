namespace ProductShop.DTOS.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserExportProductsDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
    }
}
