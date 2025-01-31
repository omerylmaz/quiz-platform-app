using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.SubscriptionBenefits;

namespace Subscriptions.Infrustructure.SubscriptionBenefits;

internal sealed class SubscriptionBenefitConfiguration : IEntityTypeConfiguration<SubscriptionBenefit>
{
    public void Configure(EntityTypeBuilder<SubscriptionBenefit> builder)
    {
        builder.HasKey(sb => sb.Id);

        builder.OwnsOne(sb => sb.Benefit, benefit =>
        {
            benefit.Property(b => b.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);

            benefit.Property(b => b.Value)
                .HasColumnName("Value")
                .IsRequired()
                .HasMaxLength(255);
        });

        builder.HasMany(s => s.Subscriptions)
            .WithMany(s => s.SubscriptionBenefits);
    }
}
