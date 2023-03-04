using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC.Entities;
using RecruitmentSITHEC.Helpers.Constantes;
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
                  new Human{Id = 1, Nombre = "Juan Perez", Sexo = Generos.Masculino, Edad = 20, Altura = 1.80M, Peso = 80.00M},
                  new Human{Id = 2, Nombre = "Pedro Hernandez", Sexo = Generos.Masculino, Edad = 25, Altura = 1.70M, Peso = 70.00M},
                  new Human{Id = 3, Nombre = "Maria Santiago", Sexo = Generos.Femenino, Edad = 30, Altura = 1.60M, Peso = 60.00M},
                  new Human{Id = 4, Nombre = "Jose Perez", Sexo = Generos.Masculino, Edad = 35, Altura = 1.60M, Peso = 50.00M},
                  new Human{Id = 5, Nombre = "Luis Jimenez", Sexo = Generos.Masculino, Edad = 40, Altura = 1.80M, Peso = 50.00M},
                  new Human{Id = 6, Nombre = "Ana Alvarado", Sexo = Generos.Femenino, Edad = 45, Altura = 1.60M, Peso = 80.00M},
                  new Human{Id = 7, Nombre = "Luisa Salazar", Sexo = Generos.Femenino, Edad = 50, Altura = 1.70M, Peso = 60.00M},
                  new Human{Id = 8, Nombre = "Luis Perez", Sexo = Generos.Masculino, Edad = 55, Altura = 1.70M, Peso = 78.00M}, 
                  new Human{Id = 9, Nombre = "Luisa Sanchez", Sexo = Generos.Masculino, Edad = 60, Altura = 1.80M, Peso = 56.00M   },
                  new Human{Id = 10, Nombre = "Maria Salazar", Sexo = Generos.Femenino, Edad = 65, Altura = 1.60M, Peso = 45.00M},
                  new Human{Id = 11, Nombre = "Maria Lino", Sexo = Generos.Femenino, Edad = 70, Altura = 1.70M, Peso = 45.00M},
                  new Human{Id = 12, Nombre = "Luisa Perez", Sexo = Generos.Femenino, Edad = 75, Altura = 1.60M, Peso = 45.00M},
              });
        }

        public DbSet<Human> Humans { get; set; }
    }
}
