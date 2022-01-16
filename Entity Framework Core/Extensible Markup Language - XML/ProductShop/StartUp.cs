using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ProductShop.DTOs;
using ProductShop.DTOs.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersXmlDoc = File.ReadAllText("../../../Datasets/users.xml");
            //string productsXmlDoc = File.ReadAllText("../../../Datasets/products.xml");
            //string categoriesXmlDoc = File.ReadAllText("../../../Datasets/categories.xml");
            //string categoryProductsXmlDoc = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(context,usersXmlDoc));
            //Console.WriteLine(ImportProducts(context, productsXmlDoc));
            //Console.WriteLine(ImportCategories(context,categoriesXmlDoc));
            //Console.WriteLine(ImportCategoryProducts(context,categoryProductsXmlDoc));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserImportDTO[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            UserImportDTO[] dtos = (UserImportDTO[])xmlSerializer.Deserialize(stringReader);

            List<User> users = new List<User>();

            foreach (var userImportDto in dtos)
            {
                User u = new User()
                {
                    FirstName = userImportDto.FirstName,
                    LastName = userImportDto.LastName,
                    Age = userImportDto.Age
                };

                users.Add(u);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductImportDTO[]), xmlRootAttribute);

            using StringReader stringReader = new StringReader(inputXml);

            ProductImportDTO[] dtos = (ProductImportDTO[])xmlSerializer.Deserialize(stringReader);

            List<Product> products = new List<Product>();

            foreach (var productImportDto in dtos)
            {
                Product p = new Product()
                {
                    Name = productImportDto.Name,
                    Price = productImportDto.Price,
                    BuyerId = productImportDto.BuyerId,
                    SellerId = productImportDto.SellerId
                };

                products.Add(p);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryImportDTO[]), xmlRootAttribute);

            using StringReader stringReader = new StringReader(inputXml);

            CategoryImportDTO[] dtos = (CategoryImportDTO[])xmlSerializer.Deserialize(stringReader);

            List<Category> categories = new List<Category>();

            foreach (var categoryImportDto in dtos.Where(c => c.Name != null))
            {
                Category c = new Category()
                {
                    Name = categoryImportDto.Name
                };

                categories.Add(c);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDTO[]), new XmlRootAttribute("CategoryProducts"));

            using StringReader stringReader = new StringReader(inputXml);

            CategoryProductImportDTO[] dtos = (CategoryProductImportDTO[])xmlSerializer.Deserialize(stringReader);

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var cp in dtos)
            {
                if (!context.Categories.Any(c => c.Id == cp.CategoryId) ||
                    !context.Products.Any(p => p.Id == cp.ProductId))
                {
                    continue;
                }

                CategoryProduct categoryProduct = new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportSoldProductsUserDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportSoldProductsUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ExportSoldProductDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,users,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportCategoryByProductsCountDto[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var categories = context.Categories
                .Select(c => new ExportCategoryByProductsCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AvgPrice = c.CategoryProducts.Average(cp=>cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp=>cp.Product.Price)
                })
                .OrderByDescending(c=>c.Count)
                .ThenBy(c=>c.TotalRevenue)
                .ToArray();

            xmlSerializer.Serialize(stringWriter,categories,namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportUsersDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.ProductsSold.Count)
                .Select(u => new ExportUsersDto()
                {
                    Count = context.Users.Count(),
                    UsersDto = context.Users.Select(u => new ExportUserDto()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Age = u.Age,
                            SoldProducts = new ExportSoldProductsCountDto()
                            {
                                Count = u.ProductsSold.Count,
                                Products = u.ProductsSold.Select(p=>new ExportProductDto()
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                }).ToArray()
                            }
                        })
                        .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter,users,namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}