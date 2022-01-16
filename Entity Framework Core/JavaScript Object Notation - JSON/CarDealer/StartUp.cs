using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string suppliersJsonString = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJsonString = File.ReadAllText("../../../Datasets/parts.json");
            //string carsJsonString = File.ReadAllText("../../../Datasets/cars.json");
            //string customersJsonString = File.ReadAllText("../../../Datasets/customers.json");
            //string salesJsonString = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersJsonString));
            //Console.WriteLine(ImportParts(context, partsJsonString));
            //Console.WriteLine(ImportCars(context, carsJsonString));
            //Console.WriteLine(ImportCustomers(context,customersJsonString));
            //Console.WriteLine(ImportSales(context,salesJsonString));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IEnumerable<SupplierImportDTO> suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierImportDTO>>(inputJson);

            InitializeMapper();

            IEnumerable<Supplier> mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersId = context.Suppliers.Select(x => x.Id).ToList();

            IEnumerable<PartImportDTO> parts = JsonConvert.DeserializeObject<IEnumerable<PartImportDTO>>(inputJson)
                .Where(p => suppliersId.Contains(p.SupplierId));

            InitializeMapper();

            IEnumerable<Part> mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<CarImportDTO> cars = JsonConvert.DeserializeObject<IEnumerable<CarImportDTO>>(inputJson);

            List<Car> carsToImport = new List<Car>();

            HashSet<int> existingParstsIds = context.Parts
                .Select(p => p.Id)
                .ToHashSet();
            InitializeMapper();

            foreach (var car in cars)
            {
                Car currentCar = mapper.Map<Car>(car);

                foreach (var partId in car.PartsId.Distinct())
                {
                    if (existingParstsIds.Contains(partId))
                    {
                        PartCar currentPart = new PartCar()
                        {
                            PartId = partId,
                            Car = currentCar
                        };

                        currentCar.PartCars.Add(currentPart);
                    }
                }

                carsToImport.Add(currentCar);
            }

            context.AddRange(carsToImport);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count()}.";

        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IEnumerable<CustomerImportDTO> customers =
                JsonConvert.DeserializeObject<IEnumerable<CustomerImportDTO>>(inputJson);
            InitializeMapper();

            IEnumerable<Customer> mappedCustomers = mapper.Map<IEnumerable<Customer>>(customers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IEnumerable<SalesImportDTO> sales = JsonConvert.DeserializeObject<IEnumerable<SalesImportDTO>>(inputJson);
            InitializeMapper();

            IEnumerable<Sale> mappedSales = mapper.Map<IEnumerable<Sale>>(sales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(cars);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(x => new
                    {
                        Name = x.Part.Name,
                        Price = ($"{x.Part.Price:f2}")
                    }).ToList()
                })
                .ToList();

            string res = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return res;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new CustomerExportTotalSales()
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = $"{s.Customer.Name}",
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(x => x.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) - (s.Car.PartCars.Sum(x => x.Part.Price) * (s.Discount / 100)):f2}"
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

    }
}