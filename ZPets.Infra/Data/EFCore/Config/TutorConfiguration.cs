using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPets.Domain.Entities.Tutors;

namespace ZPets.Infra.Data.EFCore.Config
{
    internal class TutorConfiguration : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.ToTable("tutors");
        }
    }
}
