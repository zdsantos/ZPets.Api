using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ZPets.Domain.Entities.Pets;

namespace ZPets.Infra.Data.EFCore.Config
{
    internal class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
    {
        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            builder.ToTable("vaccines");

            builder.Property(v => v.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(v => v.Pet)
                .WithMany(p => p.Vaccines)
                .HasForeignKey(v => v.PetId)
                .IsRequired();
        }
    }
}
