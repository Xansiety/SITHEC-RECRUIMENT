using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC.Entities;
using RecruitmentSITHEC.Helpers.Abstracts;
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
            MockData mockData = new MockData();
            modelBuilder.Entity<Human>()
              .HasData(mockData.HumansList());
        }
        public DbSet<Human> Humans { get; set; }

    }
}