using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Villavi.Shared.Entities;

namespace Villavi.Api
{
    public class DataContext : IdentityDbContext <User>
    {
        public DbSet <City> Cities { get; set; } 
        public DbSet <Country> Countries { get; set; }

        public DbSet <Company> Companys { get; set; }

        public DataContext (DbContextOptions<DataContext>dbContext) :base (dbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();  
            modelBuilder.Entity<City>().HasIndex(x =>x.Name).IsUnique();
            modelBuilder.Entity<Company>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
