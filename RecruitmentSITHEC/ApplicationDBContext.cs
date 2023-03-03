using Microsoft.EntityFrameworkCore;
using RecruitmentSITHEC.Entities;

namespace RecruitmentSITHEC
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Humanos> Humanos { get; set; }


    }
}
