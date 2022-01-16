using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Internal;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Data;
    using Theatre.Data.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(PlayImportDto[]), new XmlRootAttribute("Plays"));

            PlayImportDto[] dtos = (PlayImportDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            ICollection<Play> plays = new HashSet<Play>();


            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var parsedGenre = Enum.TryParse(dto.Genre, out Genre playGenre);
                if (!parsedGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play p = new Play()
                {
                    Title = dto.Title,
                    Duration = TimeSpan.Parse(dto.Duration),
                    Rating = float.Parse(dto.Rating),
                    Genre = playGenre,
                    Description = dto.Description,
                    Screenwriter = dto.Screenwriter
                };

                if (p.Duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                plays.Add(p);
                sb.AppendLine($"Successfully imported {p.Title} with genre {p.Genre} and a rating of {p.Rating}!");
            }


            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(CastImportDto[]), new XmlRootAttribute("Casts"));

            CastImportDto[] dtos = (CastImportDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            ICollection<Cast> casts = new HashSet<Cast>();


            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Cast c = new Cast()
                {
                    FullName = dto.FullName,
                    IsMainCharacter = dto.IsMainCharacter,
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId
                };

                casts.Add(c);
                string g = c.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine($"Successfully imported actor {c.FullName} as a {g} character!");
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<TheatreImportDto[]>(jsonString);

            ICollection<Theatre> theatres = new HashSet<Theatre>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Name == "")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre t = new Theatre()
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.Director
                };

                foreach (var dtoTicket in dto.Tickets)
                {
                    if (!IsValid(dtoTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ti = new Ticket()
                    {
                        Price = dtoTicket.Price,
                        RowNumber = dtoTicket.RowNumber,
                        PlayId = dtoTicket.PlayId
                    };

                    t.Tickets.Add(ti);
                }

                theatres.Add(t);
                sb.AppendLine($"Successfully imported theatre {t.Name} with #{t.Tickets.Count} tickets!");
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
