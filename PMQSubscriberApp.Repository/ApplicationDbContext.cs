using Microsoft.EntityFrameworkCore;
using PMQSubscriberApp.Entities.Models;
using PMQSubscriberApp.Repository.EntityConfiguration;

namespace PMQSubscriberApp.Repository
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzeriaEntityTypeConfiguration).Assembly);
        }

        public DbSet<Pizzeria> Pizzerias { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
