using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.Customers;
using Subscriptions.Infrustructure.Database;

namespace Subscriptions.Infrustructure.Customers;

internal sealed class CustomerRepository(SubscriptionsDbContext context) : ICustomerRepository
{
    public async Task<Customer?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public void Add(Customer customer)
    {
        context.Customers.Add(customer);
    }
}
