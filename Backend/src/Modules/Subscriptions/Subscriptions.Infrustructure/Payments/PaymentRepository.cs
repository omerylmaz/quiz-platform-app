using Microsoft.EntityFrameworkCore;
using Subscriptions.Domain.Payments;
using Subscriptions.Infrustructure.Database;

namespace Subscriptions.Infrustructure.Payments;

internal sealed class PaymentRepository(SubscriptionsDbContext dbContext) : IPaymentRepository
{
    public void Add(Payment payment)
    {
        dbContext.Payments.Add(payment);
    }

    public void Delete(Payment payment)
    {
        dbContext.Payments.Remove(payment);
    }

    public async Task<Payment?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Payments
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Payment>> GetAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken)
    {
        return await dbContext.Payments
            .AsNoTracking()
            .Where(p => p.CustomerId == customerId)
            .ToListAsync(cancellationToken);
    }
}
