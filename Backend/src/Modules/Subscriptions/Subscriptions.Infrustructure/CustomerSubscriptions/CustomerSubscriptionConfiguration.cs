using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.CustomerSubscriptions;

namespace Subscriptions.Infrustructure.CustomerSubscriptions;

internal sealed class CustomerSubscriptionConfiguration : IEntityTypeConfiguration<CustomerSubscription>
{
    public void Configure(EntityTypeBuilder<CustomerSubscription> builder)
    {
        builder.HasKey(cs => cs.Id);

        builder.HasOne(cs => cs.Customer)
            .WithMany()
            .HasForeignKey(cs => cs.CustomerId);

        builder.HasOne(cs => cs.Subscription)
            .WithMany()
            .HasForeignKey(cs => cs.SubscriptionId);
    }
}
