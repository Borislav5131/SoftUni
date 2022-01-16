using System.Collections.Generic;

namespace ProductShop.DTOS.Export
{
    public class UserExportDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<UserExportProductsDTO> soldProducts { get; set; }
    }
}
