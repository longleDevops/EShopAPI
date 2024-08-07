using System;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.RequestModels;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace OrderAPI.ApplicationCore.Contracts.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ViewOrders(int pageIndex, int pageSize);

        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task<int> CreateOrder(OrderRequestModel orderRequestModel);
        Task<int> UpdateOrder(OrderRequestModel orderRequestModel, int id);
        Task<OrderResponseModel> OrderCompleted(decimal bill, Guid customerId);
    }
}

