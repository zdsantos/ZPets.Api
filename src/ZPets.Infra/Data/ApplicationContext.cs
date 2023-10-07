using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZPets.Domain.Entities.Pets;
using ZPets.Domain.Entities.Tutors;

namespace ZPets.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<PetOwnership> PetOwnerships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
