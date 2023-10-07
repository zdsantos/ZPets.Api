using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZPets.Domain.Entities.Pets;

namespace ZPets.Infra.Data.EFCore.Config
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");

            var converter = new EnumToNumberConverter<Gender, byte>();
            builder.Property(p => p.Gender)
                .HasConversion(converter);

            builder.HasMany(p => p.Vaccines)
                .WithOne(v => v.Pet)
                .HasForeignKey(v => v.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Weights)
                .WithOne(w => w.Pet)
                .HasForeignKey(w => w.PetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
