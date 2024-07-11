using CRM_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM_API.Schemes;

public class CustomerScheme : IEntityTypeConfiguration<ECustomer>
{
    public void Configure(EntityTypeBuilder<ECustomer> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(255);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Address).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Email).HasMaxLength(255);
        builder.Property(p => p.Mobile).HasMaxLength(13);
        builder.Property(p => p.Age).IsRequired();
    }
}