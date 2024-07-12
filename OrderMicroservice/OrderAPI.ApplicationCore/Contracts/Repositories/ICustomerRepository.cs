using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories;

public interface ICustomerRepository
{
    Task<int> DeleteCustomer(Guid customerId);
    Task<Customer> GetCustomerById(Guid customerId);
}