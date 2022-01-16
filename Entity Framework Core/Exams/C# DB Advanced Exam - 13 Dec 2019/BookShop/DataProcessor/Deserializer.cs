using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(BookImportDto[]), new XmlRootAttribute("Books"));

            BookImportDto[] dtos = (BookImportDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            ICollection<Book> books = new List<Book>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var parsedPublishedOnDate = DateTime.TryParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var bookPublishedOn);
                if (!parsedPublishedOnDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book b = new Book()
                {
                    Name = dto.Name,
                    Genre = (Genre)dto.Genre,
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = bookPublishedOn
                };

                books.Add(b);
                sb.AppendLine($"Successfully imported book {b.Name} for {b.Price:f2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<AuthorImportDto[]>(jsonString);

            ICollection<Author> authors = new HashSet<Author>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || authors.Any(a=>a.Email == dto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author au = new Author()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                foreach (var dtoB in dto.Books.Distinct())
                {
                    if (!dtoB.Id.HasValue)
                    {
                        continue;
                    }

                    Book book = context.Books.FirstOrDefault(b => b.Id == dtoB.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    au.AuthorsBooks.Add(new AuthorBook()
                    {
                        Book = book,
                        Author = au
                    });
                }

                if (au.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(au);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, au.FirstName + " " + au.LastName, au.AuthorsBooks.Count));
            }


            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}