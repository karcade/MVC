using Microsoft.EntityFrameworkCore;
using WebAPI.Model.DatabaseModels;

namespace WebApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public object DatabaseModels { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User[]
               {
                new User { Id =1, Name="Evgeniusz", Username="evsz", Password = "zeka"},
                new User { Id =2, Name="Vladislaw", Username="vlad", Password = "123"},
                new User { Id =3, Name="Olga", Username="olga", Password = "963"},
                new User { Id =4, Name="Alesya", Username="less", Password = "007"},
                new User { Id =5, Name="Lubov", Username="luba", Password = "solaris"},
               });

            /*modelBuilder.Entity<WorkTask>().HasData(
              new WorkTask[]
              {
                new WorkTask { Id =1,  Description="Project 5G: fix bugs in route body", ExecutionHours=5 },
                new WorkTask { Id =2, Name="Pasre route header", Description="Project 5G: parse route header", ExecutionHours=6},
                new WorkTask { Id =3, Name="Add function", Description="Mobile project: add geolocation", ExecutionHours=2},
                new WorkTask { Id =4, Name="Sorting", Description="Training: realize sorting algorithm", ExecutionHours=1},
                new WorkTask { Id =5, Name="Analysis", Description="Site gov.ua: analyse users data", ExecutionHours=5},
              });*/
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }*/
    }
}
