using CRM_API.Entities;
using CRM_API.Schemes;
using Microsoft.EntityFrameworkCore;

namespace CRM_API;

public class CRMDBContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<EUser> Users { get; set; }

    public CRMDBContext(DbContextOptions<CRMDBContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserScheme());
        base.OnModelCreating(modelBuilder);
    }
}