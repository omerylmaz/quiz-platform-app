namespace Subscriptions.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Customer customer);
}
