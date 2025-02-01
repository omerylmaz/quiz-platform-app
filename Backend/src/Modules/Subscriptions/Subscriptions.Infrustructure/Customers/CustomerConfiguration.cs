using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Payments;

namespace Subscriptions.Infrustructure.Customers;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName).HasMaxLength(200);

        builder.Property(c => c.LastName).HasMaxLength(200);

        builder.Property(c => c.Email).HasMaxLength(300);

        builder.HasIndex(c => c.Email).IsUnique();

        builder.HasMany<Payment>()
            .WithOne(p => p.Customer);
    }
}
