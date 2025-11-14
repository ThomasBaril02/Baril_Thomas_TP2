using JuliePro.Models;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Data
{
    public class JulieProDbContext : DbContext
    {

        public JulieProDbContext()
        {

        }

        public JulieProDbContext(DbContextOptions<JulieProDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("scaffolding");


            }
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<TrainerCertification> TrainerCertifications { get; set; }
        public DbSet<Certification> Certifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }

    }
}