using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecruitmentSITHEC.Entities.Configuration
{
    public class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.ToTable("Humano");

            builder.Property(p => p.Id)
                    .IsRequired();

            builder.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(180);

            builder.Property(p => p.Sexo)
                .IsRequired();

            builder.Property(p => p.Edad)
                .IsRequired();

            builder.Property(p => p.Altura)
                .IsRequired();
        }
    }
}
