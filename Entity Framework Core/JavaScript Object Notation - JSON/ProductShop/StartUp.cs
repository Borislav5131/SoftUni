using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOS;
using ProductShop.DTOS.Export;
using ProductShop.DTOS.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //string productsJsonString = File.ReadAllText("../../../Datasets/products.json");
            //string usersJsonString = File.ReadAllText("../../../Datasets/users.json");
            //string categoriesJsonString = File.ReadAllText("../../../Datasets/categories.json");
            //string categoryProductsJsonString = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context,usersJsonString));
            //Console.WriteLine(ImportProducts(context, productsJsonString));
            //Console.WriteLine(ImportCategories(context,categoriesJsonString));
            //Console.WriteLine(ImportCategoryProducts(context,categoryProductsJsonString));

            Console.WriteLine(GetUsersWithProducts(context));
        }
        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = new Mapper(mapperConfiguration);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserImportDTO> users = JsonConvert.DeserializeObject<IEnumerable<UserImportDTO>>(inputJson);
            InitializeMapper();

            IEnumerable<User> mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductImportDTO> products =
                JsonConvert.DeserializeObject<IEnumerable<ProductImportDTO>>(inputJson);
            InitializeMapper();

            IEnumerable<Product> mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesImportDTO> categories = JsonConvert.DeserializeObject<IEnumerable<CategoriesImportDTO>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));

            InitializeMapper();

            IEnumerable<Category> mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProductsImportDTO> categoryProducts =
                JsonConvert.DeserializeObject<IEnumerable<CategoryProductsImportDTO>>(inputJson);

            InitializeMapper();

            IEnumerable<CategoryProduct> mappedCategoryProducts =
                mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductsExportInRangeDTO()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var result = JsonConvert.SerializeObject(products, jsonSettings);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Include(p => p.ProductsSold)
                .Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new UserExportDTO()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(p => new UserExportProductsDTO()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    }).ToList()

                }).ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var result = JsonConvert.SerializeObject(users, jsonSettings);
            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //var categories = context
            //    .Categories
            //    .OrderByDescending(x => x.CategoryProducts.Count)
            //    .Select(x => new CategoryProductsExportDTO()
            //    {
            //        Category = x.Name,
            //        ProductsCount = x.CategoryProducts.Count,
            //        AveragePrice = $"{(x.CategoryProducts.Sum(p => p.Product.Price) / x.CategoryProducts.Count):f2}",
            //        TotalRevenue = $"{x.CategoryProducts.Sum(p => p.Product.Price):f2}"
            //    })
            //    .ToList();

            InitializeMapper();
            var categories = context
                .Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .ProjectTo<CategoryProductsExportDTO>(mapper.ConfigurationProvider)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var result = JsonConvert.SerializeObject(categories, jsonSettings);
            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x=>x.ProductsSold)
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null) && u.FirstName != null && u.LastName != null)
                .Select(x => new UserProductsExportDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ProductsExportDto
                    {
                        Count = x.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Count(),

                        Products = x.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new ProductExportDto
                            {
                                Name = p.Name,
                                Price = p.Price,
                            })
                            .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();
            var result = new UsersWithSoldProductsExportDTO
            {
                UsersCount = users.Count,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };


            return JsonConvert.SerializeObject(result, jsonSettings); ;
        }

    }
}