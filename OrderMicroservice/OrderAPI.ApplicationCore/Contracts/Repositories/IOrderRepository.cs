using System;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
	public interface IOrderRepository:IAsyncRepository<Order>
	{
		Task<Order> GetOrderCustomerById(int orderId, Guid customerId);
		Task<IEnumerable<Order>> GetAllOrders(int pageIndex, int pageSize);
		Task<Order> GetOrderByBillCustomerId(decimal bill, Guid customerId);

	}
}

