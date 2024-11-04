using CustomerManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure;

public class CustomerManagementContext(DbContextOptions<CustomerManagementContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Seed initial data
        modelBuilder.Entity<Customer>().HasData(
            new Customer{ Id = 1, Name = "Leanne Fairclough", Address = "6 Station Road", PhoneNumber = "01743 845569"}
        );
    }

}