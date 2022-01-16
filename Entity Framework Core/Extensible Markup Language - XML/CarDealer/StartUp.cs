using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using CarDealer.Models.ImportDTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using CarDealer.Models.ExportDTOs;

namespace CarDealer
{
    public class StartUp
    {
        //private static readonly IMapper mapper =
        //    new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>()));

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string importSuppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string importPartsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string importCarsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string importCustomersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string importSalesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(context,importSuppliersXml));
            //Console.WriteLine(ImportParts(context,importPartsXml));
            //Console.WriteLine(ImportCars(context,importCarsXml));
            //Console.WriteLine(ImportCustomers(context,importCustomersXml));
            //Console.WriteLine(ImportSales(context,importSalesXml));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDTO[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            SupplierImportDTO[] supplierDTOs = (SupplierImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var dto in supplierDTOs)
            {
                Supplier s = new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                };

                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartImportDTO[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            PartImportDTO[] partsDtos = (PartImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var dto in partsDtos)
            {
                if (!context.Suppliers.Any(s=>s.Id == dto.SupplierId))
                {
                    continue;;
                }

                Part p = new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                };

                parts.Add(p);
            }

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarImportDTO[]), xmlRoot);

            StringReader stringReader = new StringReader(inputXml);

            CarImportDTO[] carsDtos = (CarImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();
            ICollection<PartCar> partCars = new HashSet<PartCar>();

            foreach (var dto in carsDtos)
            {
                Car c = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance,
                };

                foreach (var partId in dto.PartCars.Select(p=>p.Id).Distinct())
                {
                    if (!context.Parts.Contains(new Part(){Id=partId}))
                    {
                        continue;
                    }

                    PartCar pc = new PartCar()
                    {
                        Car = c,
                        PartId = partId
                    };

                    c.PartCars.Add(pc);
                }

                cars.Add(c);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(CustomerImportDTO[]), new XmlRootAttribute("Customers"));

            StringReader stringReader = new StringReader(inputXml);

            ICollection<CustomerImportDTO> dtos = (CustomerImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var dto in dtos)
            {
                Customer c = new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                };

                customers.Add(c);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleImportDTO[]), new XmlRootAttribute("Sales"));

            StringReader stringReader = new StringReader(inputXml);

            ICollection<SaleImportDTO> dtos = (SaleImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var dto in dtos)
            {
                if (!context.Cars.Any(c=>c.Id == dto.CarId))
                {
                    continue;
                }

                Sale s = new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount
                };

                sales.Add(s);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportCarsWithDistanceDTO[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty,string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c=> new ExportCarsWithDistanceDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,cars,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportCarsWithMakeBMWDTO[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var BMWs = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarsWithMakeBMWDTO()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,BMWs,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportLocalSuppliersDTO[]), new XmlRootAttribute("suppliers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,suppliers,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportCarsWithTheirListOfPartsDTO[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarsWithTheirListOfPartsDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc=>new ExportCarPartDTO()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p=>p.Price)
                    .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,cars,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportTotalSaleByCustomerDTO[]), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var customers = context.Customers
                .ToArray()
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportTotalSaleByCustomerDTO()
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(m=>m.Car.PartCars.Sum(pc=>pc.Part.Price))
                })
                .OrderByDescending(c=>c.SpentMoney)
                .ToArray();

            xmlSerializer.Serialize(stringWriter,customers,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportSalesWithAppliedDiscountDTO[]), new XmlRootAttribute("sales"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var sales = context.Sales
                .Select(s => new ExportSalesWithAppliedDiscountDTO()
                {
                    Car = new ExportCarDTO()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc=>pc.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price)) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100))
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,sales,namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}