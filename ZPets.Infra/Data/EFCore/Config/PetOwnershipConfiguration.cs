using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPets.Domain.Entities.Tutors;

namespace ZPets.Infra.Data.EFCore.Config
{
    internal class PetOwnershipConfiguration : IEntityTypeConfiguration<PetOwnership>
    {
        public void Configure(EntityTypeBuilder<PetOwnership> builder)
        {
            builder.ToTable("pet_ownership");

            builder.HasOne(po => po.Pet)
                .WithMany(p => p.PetOwners)
                .HasForeignKey(po => po.PetId);

            builder.HasOne(po => po.Tutor)
                .WithMany(t => t.Pets)
                .HasForeignKey(po => po.TutorId);

            builder.Property(po => po.PetId)
                .IsRequired();

            builder.Property(po => po.TutorId)
                .IsRequired();
        }
    }
}
