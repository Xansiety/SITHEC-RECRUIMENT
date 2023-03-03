using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC.Entities;
using System.Reflection;

namespace RecruitmentSITHEC
{
    public class ApplicationDBContext : DbContext
    { 
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Human>()
              .HasData(new List<Human>
              {
                  new Human{Id = 1, Nombre = "Juan", Sexo = 'H', Edad = 20, Altura = 1.80M, Peso = 80.00M},
                  new Human{Id = 2, Nombre = "Pedro", Sexo = 'H', Edad = 25, Altura = 1.70M, Peso = 70.00M},
                  new Human{Id = 3, Nombre = "Maria", Sexo = 'M', Edad = 30, Altura = 1.60M, Peso = 60.00M},
                  new Human{Id = 4, Nombre = "Jose", Sexo = 'H', Edad = 35, Altura = 1.50M, Peso = 50.00M},
                  new Human{Id = 5, Nombre = "Luis", Sexo = 'H', Edad = 40, Altura = 1.40M, Peso = 40.00M},
                  new Human{Id = 6, Nombre = "Ana", Sexo = 'M', Edad = 45, Altura = 1.30M, Peso = 30.00M},
                  new Human{Id = 7, Nombre = "Luisa", Sexo = 'M', Edad = 50, Altura = 1.20M, Peso = 20.00M},
                  new Human{Id = 8, Nombre = "Luis", Sexo = 'H', Edad = 55, Altura = 1.10M, Peso = 10.00M},
                  new Human{Id = 9, Nombre = "Luisa", Sexo = 'M', Edad = 60, Altura = 1.00M, Peso = 5.00M},
                  new Human{Id = 10, Nombre = "Luis", Sexo = 'H', Edad = 65, Altura = 0.90M, Peso = 4.00M},
              });
        }

        public DbSet<Human> Humans { get; set; }
    }
}
