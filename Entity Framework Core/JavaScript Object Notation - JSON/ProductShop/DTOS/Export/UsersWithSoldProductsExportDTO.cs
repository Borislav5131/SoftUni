using System.Collections.Generic;
using ProductShop.Models;

namespace ProductShop.DTOS.Export
{
    public class UsersWithSoldProductsExportDTO
    {
        public int UsersCount { get; set; }
        public IEnumerable<UserProductsExportDTO> Users { get; set; }
    }
}
