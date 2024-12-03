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
        public DbSet <Client> Clients { get; set; }
        public DbSet <Car> Cars { get; set; }
        public DbSet <Service> Services { get; set; }
        public DbSet <Mechanic> Mechanics { get; set; }
        public DbSet <DetailService> Details { get; set; }
        public DbSet <Supplier> Suppliers { get; set; }
        public DbSet <Order> Orders { get; set; }

        public DataContext (DbContextOptions<DataContext>dbContext) :base (dbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Company>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Car>().HasIndex(x => x.Plate).IsUnique();

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Cars)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetailService>()
                .HasOne(ds => ds.Service)
                .WithMany(s => s.DetailServices)
                .HasForeignKey(ds => ds.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Mechanic)
                .WithMany(m => m.Services)
                .HasForeignKey(s => s.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Mechanic)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Supplier)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }



    }
}
