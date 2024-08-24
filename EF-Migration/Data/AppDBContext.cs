
using EF_Migration.Data.Config;
using EF_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_Migration.Data
{
    public class AppDBContext:DbContext
    {
        DbSet<Course> courses {  get; set; }
        DbSet<Instructor> instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // Not Best Practice config per Class

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);

        }
    }
}
