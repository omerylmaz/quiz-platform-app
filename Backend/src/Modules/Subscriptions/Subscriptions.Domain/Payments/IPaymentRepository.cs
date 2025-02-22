﻿namespace Subscriptions.Domain.Payments;

public interface IPaymentRepository
{
    void Add(Payment payment);
    void Delete(Payment payment);
    Task<Payment?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Payment>> GetAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
}
