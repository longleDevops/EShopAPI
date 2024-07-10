using System;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
	public class OrderRepository:EfRepository<Order>,IOrderRepository
	{
		public OrderRepository(EShopDbContext dbContext):base(dbContext)
		{
		}

      
    }
}

