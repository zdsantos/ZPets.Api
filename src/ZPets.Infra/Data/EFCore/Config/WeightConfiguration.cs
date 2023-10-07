using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPets.Domain.Entities.Pets;

namespace ZPets.Infra.Data.EFCore.Config
{
    internal class WeightConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {
            builder.ToTable("weights");

            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(w => w.Pet)
                .WithMany(p => p.Weights)
                .HasForeignKey(w => w.PetId)
                .IsRequired();
        }
    }
}
