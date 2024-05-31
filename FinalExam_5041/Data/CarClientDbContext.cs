using FinalExam_5041.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam_5041.Data
{
    public class CarClientDbContext : DbContext
    {
            public CarClientDbContext(DbContextOptions<CarClientDbContext> options) : base(options)
            {
            
            }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Car> Cars { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<Car>(entity =>
                {
                    entity.Property(r => r.Model).IsRequired();
                });

                modelBuilder.Entity<Client>(entity =>
                {
                    entity.HasOne(g => g.Car)
                          .WithMany(r => r.Clients)
                          .HasForeignKey(g => g.CarId);
                });
            }
        }
    }
