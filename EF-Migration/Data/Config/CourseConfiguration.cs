using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Migration.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255); ==> NVarchar!!? 
            builder.Property(x => x.CourseName)
                .IsRequired()
                .HasColumnType("VARCHAR")//=> varchar
                .HasMaxLength(255);

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);

            builder.ToTable("Courses");

            builder.HasData(LoadCourses());

        }

        private static List<Course> LoadCourses()
        {
            /*
             INSERT INTO Courses (Id, CourseName, Price) VALUES (1, 'Mathematics', 1000.00);
             INSERT INTO Courses (Id, CourseName, Price) VALUES (2, 'Physics', 2000.00);
             INSERT INTO Courses (Id, CourseName, Price) VALUES (3, 'Chemistry', 1500.00);
             INSERT INTO Courses (Id, CourseName, Price) VALUES (4, 'Biology', 1200.00);
             INSERT INTO Courses (Id, CourseName, Price) VALUES (5, 'Computer Science', 3000.00);
            */
            return new List<Course>
            {
                new Course(){Id = 1,CourseName="Mathematics",Price=1000m},
                new Course(){Id = 2,CourseName="Physics",Price=2000m},
                new Course(){Id = 3,CourseName="Chemistry",Price=1500m},
                new Course(){Id = 4,CourseName="Biology",Price=1200m},
                new Course(){Id = 5,CourseName="Computer",Price=3000m},

            };
        }
    }
}
