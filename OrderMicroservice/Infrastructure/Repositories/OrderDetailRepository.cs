using System;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
	public class OrderDetailRepository:EfRepository<OrderDetails>, IOrderDetailRepository
	{
		public OrderDetailRepository(EShopDbContext dbContext):base(dbContext)
		{
		}
	}
}

