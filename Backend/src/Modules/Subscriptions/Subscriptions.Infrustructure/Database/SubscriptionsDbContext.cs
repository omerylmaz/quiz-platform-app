using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Subscriptions.Application.Abstractions.Data;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.CustomerSubscriptions;
using Subscriptions.Domain.Payments;
using Subscriptions.Domain.SubscriptionBenefits;
using Subscriptions.Domain.Subscriptions;

namespace Subscriptions.Infrustructure.Database;

public sealed class SubscriptionsDbContext(DbContextOptions<SubscriptionsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Subscription> Subscriptions { get; set; }
    internal DbSet<SubscriptionBenefit> SubscriptionBenefits { get; set; }
    internal DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
    internal DbSet<Payment> Payments { get; set; }
    internal DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDefaultSchema(Schemas.Subscriptions);
    }
}
