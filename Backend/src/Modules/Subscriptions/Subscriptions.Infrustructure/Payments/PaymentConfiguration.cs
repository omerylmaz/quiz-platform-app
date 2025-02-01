using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.Payments;

namespace Subscriptions.Infrustructure.Payments;

internal sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(p => p.TransactionId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.PaymentStatus)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerId);
    }
}
