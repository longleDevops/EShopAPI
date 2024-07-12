using System;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.RequestModels;
using OrderAPI.ApplicationCore.Models.ResponseModels;

namespace OrderAPI.Infrastructure.Services
{
	public class OrderService:IOrderService
	{
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

		public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
		{
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
		}

        public async Task<int> CreateOrder(OrderRequestModel orderRequestModel)
        {
            var order = new Order();
            order.OrderDate = orderRequestModel.OrderDate;
            order.CustomerName = orderRequestModel.CustomerName;
            order.CustomerId = orderRequestModel.CustomerId;
            order.CustomerName = orderRequestModel.CustomerName;
            order.PaymentMethod= orderRequestModel.PaymentMethod;
            order.PaymentName = orderRequestModel.PaymentName;
            order.ShippingAddress = orderRequestModel.ShippingAddress;
            order.ShippingMethod = orderRequestModel.ShippingMethod;
            order.BillAmount = orderRequestModel.BillAmount;
            order.OrderStatusId = orderRequestModel.OrderStatusId;
            
            return await _orderRepository.Create(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<int> UpdateOrder(OrderRequestModel orderRequestModel, int id)
        {
            var order = new Order();
            order.Id = id;
            order.OrderDate = orderRequestModel.OrderDate;
            order.CustomerName = orderRequestModel.CustomerName;
            order.CustomerId = orderRequestModel.CustomerId;
            order.CustomerName = orderRequestModel.CustomerName;
            order.PaymentMethod = orderRequestModel.PaymentMethod;
            order.PaymentName = orderRequestModel.PaymentName;
            order.ShippingAddress = orderRequestModel.ShippingAddress;
            order.ShippingMethod = orderRequestModel.ShippingMethod;
            order.BillAmount = orderRequestModel.BillAmount;
            order.OrderStatusId = orderRequestModel.OrderStatusId;

            return await _orderRepository.Update(order);
        }

        public Task<OrderResponseModel> OrderCompleted(decimal bill, Guid customerId)
        {
            var entity = _orderRepository.GetOrderByBillCustomerId(bill, customerId);
            return null;
        }

        
        public Task<IEnumerable<Order>> ViewOrders(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        
        
    }
}

