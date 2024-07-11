using CRM_API.Entities;
using CRM_API.Schemes;
using Microsoft.EntityFrameworkCore;

namespace CRM_API;

public class CRMDBContext : DbContext
{
    public DbSet<EUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=customer_relationship_management;user=root;password=admin");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserScheme());
        base.OnModelCreating(modelBuilder);
    }
}