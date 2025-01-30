using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Infrustructure.Subscriptions;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(s => s.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.HasMany(s => s.SubscriptionBenefits)
            .WithOne()
            .HasForeignKey(sb => sb.SubscriptionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
