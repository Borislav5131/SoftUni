using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    using System;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options)
        :base(options)
        {
            
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=SoftUni;User id = sa;pwd = SoftUniserver! ;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(x => x.Name).IsUnicode();
            modelBuilder.Entity<Student>().Property(x => x.PhoneNumber).IsUnicode(false);
            modelBuilder.Entity<Course>().Property(x => x.Name).IsUnicode();
            modelBuilder.Entity<Course>().Property(x => x.Description).IsUnicode();
            modelBuilder.Entity<Resource>().Property(x => x.Name).IsUnicode();
            modelBuilder.Entity<Resource>().Property(x => x.Url).IsUnicode(false);
            modelBuilder.Entity<Homework>().Property(x => x.Content).IsUnicode(false);
            modelBuilder.Entity<StudentCourse>(x=>x.HasKey(x=>new {x.StudentId,x.CourseId}));
        }
    }
}
