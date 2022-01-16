namespace ProductShop.DTOS.Export
{
    public class UserProductsExportDTO
    {
        public string FirstName { get; set; }

            public string LastName { get; set; }

            public int? Age { get; set; }

            public ProductsExportDto SoldProducts { get; set; }
        
    }
}
