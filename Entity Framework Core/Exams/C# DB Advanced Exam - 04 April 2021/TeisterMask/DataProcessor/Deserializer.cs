using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;
    using TeisterMask.Data.Models.Enums;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));

            ImportProjectDto[] dtos = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            ICollection<Project> projects = new HashSet<Project>();

            foreach (var d in dtos)
            {
                if (!IsValid(d))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var parsedOpenDate = DateTime.TryParseExact(d.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var projectDateOpen);
                if (!parsedOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDateDue = null;
                if (!String.IsNullOrWhiteSpace(d.DueDate))
                {
                    var parsedDueDate = DateTime.TryParseExact(d.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt);

                    if (!parsedDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDateDue = dt;
                }

                Project p = new Project()
                {
                    Name = d.Name,
                    OpenDate = projectDateOpen,
                    DueDate = projectDateDue,
                    Tasks = new List<Task>()
                };

                foreach (var task in d.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var parsedTaskOpenDate = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskDateOpen);
                    if (!parsedTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var parsedTaskDueDate = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var taskDateDue);
                    if (!parsedTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDateOpen < p.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (p.DueDate.HasValue && taskDateDue > p.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = task.Name,
                        OpenDate = taskDateOpen,
                        DueDate = taskDateDue,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };

                    p.Tasks.Add(t);
                }

                projects.Add(p);
                sb.AppendLine($"Successfully imported project - {p.Name} with {p.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            ICollection<Employee> employees = new HashSet<Employee>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    EmployeesTasks = new List<EmployeeTask>()
                };

                foreach (var taskId in dto.Tasks.Distinct())
                {
                    Task t = context.Tasks.Find(taskId);

                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask et = new EmployeeTask()
                    {
                        TaskId = taskId,
                        EmployeeId = e.Id
                    };

                    e.EmployeesTasks.Add(et);
                }

                employees.Add(e);
                sb.AppendLine($"Successfully imported employee - {e.Username} with {e.EmployeesTasks.Count} tasks.");
            }

            context.AddRange(employees);
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