using System.Reflection;
using Common.Application.Data;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.Payments;
using Subscriptions.Domain.SubscriptionBenefits;
using Subscriptions.Domain.Subscriptions;
using Subscriptions.Domain.UserSubscriptions;

namespace Subscriptions.Infrustructure.Database;

public sealed class SubscriptionsDbContext(DbContextOptions<SubscriptionsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Subscription> Subscriptions { get; set; }
    internal DbSet<SubscriptionBenefit> SubscriptionBenefits { get; set; }
    internal DbSet<UserSubscription> UserSubscriptions { get; set; }
    internal DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDefaultSchema(Schemas.Subscriptions);
    }
}
