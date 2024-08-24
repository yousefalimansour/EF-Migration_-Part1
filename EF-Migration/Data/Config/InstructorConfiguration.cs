using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.CourseName).HasMaxLength(255); ==> NVarchar!!? 
            builder.Property(x => x.FName)
                .IsRequired()
                .HasColumnType("VARCHAR")//=> varchar
                .HasMaxLength(55);
            builder.Property(x => x.LName)
               .IsRequired()
               .HasColumnType("VARCHAR")//=> varchar
               .HasMaxLength(55);

            builder.ToTable("Instructors");
            builder.HasData(LoadInstructors());
        }
        private static List<Instructor> LoadInstructors()
        {
            /*
                INSERT INTO Instructors (Id, Name, OfficeId) VALUES (1, 'Ahmed Abdullah', 1);
                INSERT INTO Instructors (Id, Name, OfficeId) VALUES (2, 'Yasmeen Mohammed', 2);
                INSERT INTO Instructors (Id, Name, OfficeId) VALUES (3, 'Khalid Hassan', 3);
                INSERT INTO Instructors (Id, Name, OfficeId) VALUES (4, 'Nadia Ali', 4);
                INSERT INTO Instructors (Id, Name, OfficeId) VALUES (5, 'Omar Ibrahim', 5);
            */
            return new List<Instructor>
            {
                new Instructor(){Id = 1,FName="Ahmed", LName="Abdullah" },
                new Instructor(){Id = 2,FName="Yasmeen",LName="Mohammed" },
                new Instructor(){Id = 3,FName="Khalid",LName="Hassan" },
                new Instructor(){Id = 4,FName="Nadia",LName="Ali" },
                new Instructor(){Id = 5,FName="Omar",LName="Ibrahim" },
            };
        }
    }
}
