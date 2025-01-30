using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscriptions.Domain.UserSubscriptions;

namespace Subscriptions.Infrustructure.UserSubscriptions;

internal sealed class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.HasKey(us => us.Id);
    }
}
