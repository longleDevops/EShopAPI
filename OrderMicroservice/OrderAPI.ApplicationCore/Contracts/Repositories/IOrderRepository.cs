using System;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
	public interface IOrderRepository:IAsyncRepository<Order>
	{
	}
}

