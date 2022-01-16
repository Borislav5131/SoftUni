using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ImportDto;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Internal;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<DepartmentImportDto[]>(jsonString);

            ICollection<Department> departments = new List<Department>();

            foreach (var dto in dtos)
            {
                bool isCellInvalid = false;

                if (!IsValid(dto) || dto.Cells.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department d = new Department()
                {
                    Name = dto.Name,
                };


                foreach (var dtoc in dto.Cells)
                {
                    if (!IsValid(dtoc))
                    {
                        isCellInvalid = true;
                        break;
                    }

                    Cell c = new Cell()
                    {
                        CellNumber = dtoc.CellNumber,
                        HasWindow = dtoc.HasWindow
                    };

                    d.Cells.Add(c);
                }

                if (isCellInvalid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                departments.Add(d);
                sb.AppendLine($"Imported {d.Name} with {d.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<PrisonerImportDto[]>(jsonString);

            ICollection<Prisoner> prisoners = new List<Prisoner>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Bail < 0 || !dto.Mails.All(m=>IsValid(m)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var parsedIncarcerationDate = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var prisonerIncarcerationDate);
                if (!parsedIncarcerationDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? prisonerReleaseDate = null;
                if (!String.IsNullOrWhiteSpace(dto.ReleaseDate))
                {
                    var parsedReleaseDatee = DateTime.TryParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);

                    if (!parsedReleaseDatee)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    prisonerReleaseDate = dt;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = prisonerIncarcerationDate,
                    ReleaseDate = prisonerReleaseDate,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                };

                foreach (var dtoMail in dto.Mails)
                {
                    Mail m = new Mail()
                    {
                        Description = dtoMail.Description,
                        Sender = dtoMail.Sender,
                        Address = dtoMail.Address
                    };

                    p.Mails.Add(m);
                }

                prisoners.Add(p);
                sb.AppendLine($"Imported {p.FullName} {p.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(OfficerImportDto[]), new XmlRootAttribute("Officers"));

            OfficerImportDto[] dtos = (OfficerImportDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            ICollection<Officer> officers = new List<Officer>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || dto.Money < 0)
                {
                    sb.AppendLine("Invalid Data");
                }

                var parsedPosition = Enum.TryParse(dto.Position, out Position officerPosition);
                if (!parsedPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var parsedWeapon = Enum.TryParse(dto.Weapon, out Weapon officerWeapon);
                if (!parsedWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer o = new Officer()
                {
                    FullName = dto.Name,
                    Salary = dto.Money,
                    Position = officerPosition,
                    Weapon = officerWeapon,
                    DepartmentId = dto.DepartmentId
                };

                foreach (var dtoPrisoner in dto.Prisoners)
                {
                    OfficerPrisoner op = new OfficerPrisoner()
                    {
                        Officer = o,
                        Prisoner = context.Prisoners.FirstOrDefault(p=>p.Id == dtoPrisoner.Id)
                    };

                    o.OfficerPrisoners.Add(op);
                }

                officers.Add(o);
                sb.AppendLine($"Imported {o.FullName} ({o.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}