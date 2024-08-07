using System;
using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.ResponseModels;
using ProductAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
	public class OrderRepository:EfRepository<Order>,IOrderRepository
	{
		public OrderRepository(EShopDbContext dbContext):base(dbContext)
		{
		}

		public async Task<Order> GetOrderCustomerById(int orderId, Guid customerId)
		{
			var entity = await _dbContext.Orders.Where(o => o.Id == orderId && o.CustomerId == customerId)
				.FirstOrDefaultAsync();
			if (entity == null) return null;
			return entity;
		}

		public Task<IEnumerable<Order>> GetAllOrders(int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public async Task<Order> GetOrderByBillCustomerId(decimal bill, Guid customerId)
		{
			var orderEntity = await _dbContext.Orders.Where(o => o.BillAmount == bill && o.CustomerId == customerId)
				.FirstOrDefaultAsync();
			return orderEntity;
		}
	}
}

