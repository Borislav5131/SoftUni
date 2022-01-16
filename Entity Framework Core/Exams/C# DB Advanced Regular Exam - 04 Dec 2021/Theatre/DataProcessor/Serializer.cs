using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Select(ti => new
                    {
                        Price =decimal.Parse($"{ti.Price:F2}"),
                        ti.RowNumber
                    }).OrderByDescending(ti => ti.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(PlayExortDto[]), new XmlRootAttribute("Plays"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);

            var plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(p => new PlayExortDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(x=>x.IsMainCharacter == true)
                        .Select(a=>new ActorExportDto()
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{a.Play.Title}'."
                    }).OrderByDescending(x=>x.FullName).ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x=>x.Genre)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
