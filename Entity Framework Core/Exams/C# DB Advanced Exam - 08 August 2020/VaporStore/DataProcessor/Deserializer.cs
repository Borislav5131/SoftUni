using System.Globalization;
using System.Linq;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);

			ICollection<Game> games = new List<Game>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Tags.Length <= 0 || dto.Price < 0)
                {
                    sb.AppendLine("Invalid data!");
					continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == dto.Developer);
                if (developer == null)
                {
                    developer = new Developer()
                    {
						Name = dto.Developer
                    };

                    context.Developers.Add(developer);
                }

                var genre = context.Genres.FirstOrDefault(g => g.Name == dto.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = dto.Genre
                    };

                    context.Genres.Add(genre);
                }

                ICollection<Tag> tags = new List<Tag>();

                foreach (var tagName in dto.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag()
                        {
                            Name = tagName
                        };
                    }

                    tags.Add(tag);
                    context.Tags.Add(tag);
                }

                var parsedReleaseDate = DateTime.TryParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtoRealeaseDate);
                if (!parsedReleaseDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }


                Game g = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = dtoRealeaseDate,
                    Developer = developer,
                    Genre = genre
                };

                ICollection<GameTag> gameTags = new List<GameTag>();

                foreach (var tag in tags)
                {
                    GameTag gt = new GameTag() { Tag = tag, Game = g };

                    gameTags.Add(gt);
                }

                g.GameTags = gameTags;

                games.Add(g);
                sb.AppendLine($"Added {g.Name} ({g.Genre.Name}) with {g.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}