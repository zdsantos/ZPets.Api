using Microsoft.EntityFrameworkCore;
using ZPets.Api.Entities;

namespace ZPets.Api.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public string DbPath { get; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "pets.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().ToTable("pets")
                .HasMany(p => p.Tutors)
                .WithMany(t => t.Pets)
                .UsingEntity<PetOwnership>();

            modelBuilder.Entity<Tutor>().ToTable("tutors")
                .HasMany(t => t.Pets)
                .WithMany(p => p.Tutors)
                .UsingEntity<PetOwnership>();

            //modelBuilder.Entity<PetOwnership>().ToTable("pet_ownerships").HasNoKey();
                //.HasAlternateKey(nameof(PetOwnership.PetId), nameof(PetOwnership.TutorId));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<PetOwnership> PetOwnerships { get; set; }
    }
}
