using System.Security.Principal;

namespace CarDealer.DTO.Export
{
    public class CustomerExportTotalSales
    {
        public string fullName { get; set; }
        public int boughtCars { get; set; }
        public decimal spentMoney { get; set; }
    }
}
