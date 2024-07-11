using CRM_API.Entities;
using CRM_API.Schemes;
using Microsoft.EntityFrameworkCore;

namespace CRM_API;

public class CRMDBContext : DbContext
{
    public DbSet<ECustomer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=customer_relationship_management;user=root;password=admin");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerScheme());
        base.OnModelCreating(modelBuilder);
    }
}