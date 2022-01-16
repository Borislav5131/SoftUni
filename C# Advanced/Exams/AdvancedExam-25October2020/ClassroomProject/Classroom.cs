
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return Students.Count;
            }
        }

        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var neededStudent = Students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if (Students.Contains(neededStudent))
            {
                Students.Remove(neededStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (Students.Any(x => x.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                var list = Students.Where(x => x.Subject == subject);

                foreach (var student in list)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
        }
    }
}
