using System;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models.RequestModels;
using OrderMicroserviceAPI.Helper;

namespace OrderMicroserviceAPI.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class OrderController:ControllerBase
	{
		private readonly IOrderService _orderService;
		Notification notification;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
			notification = new Notification();
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
		{
			var orders = await _orderService.GetOrders();
			return Ok(orders);
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateOrders(OrderRequestModel orderRequestModel)
		{
			var result = await _orderService.CreateOrder(orderRequestModel);
			if (result > 0) return Ok(result);
			return BadRequest(result);
		}

		[HttpPost("CreateOrder")]
		public IActionResult CreateOrder()
		{
			notification.AddMessageToQueue("Order Created");
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<ActionResult<int>> UpdateOrder(OrderRequestModel orderRequestModel, int id)
		{
			var result = await _orderService.UpdateOrder(orderRequestModel,id);
            if (result > 0) return Ok(result);
            return BadRequest(result);
        }
	}
}

