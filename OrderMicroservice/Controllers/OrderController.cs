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
		private readonly IRabbitMqProducerConsumer _rabbitMQProducer;

		Notification notification;
		
		public OrderController(IOrderService orderService, IRabbitMqProducerConsumer rabbitMQProducer)
		{
			_orderService = orderService;
			_rabbitMQProducer = rabbitMQProducer;
			notification = new Notification();
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
		{
			var orders = await _orderService.GetOrders();
			return Ok(orders);
		}

		[HttpPost("CreateOrder")]
		public async Task<ActionResult<int>> CreateOrder([FromBody] OrderRequestModel orderRequestModel)
		{
			try
			{
				var result = await _orderService.CreateOrder(orderRequestModel);
				if (result == 1) return Ok("Order created successfully");
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
			
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<ActionResult<int>> UpdateOrder(OrderRequestModel orderRequestModel, int id)
		{
			var result = await _orderService.UpdateOrder(orderRequestModel,id);
            if (result > 0) return Ok(result);
            return BadRequest(result);
        }
		
		[HttpPost("OrderCompleted")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> OrderCompleted(decimal bill, Guid customerId, string customerEmail)
		{
			// try
			// {
			// 	//string email = null;
			// 	//ClaimsPrincipal user = User;
			// 	//Claim emailClaim = user.FindFirst(ClaimTypes.Email);
			// 	//if (emailClaim != null)
			// 	//{
			// 	//    email = emailClaim.Value;
			// 	//}
   //              
			// 	var result = await _orderService.OrderCompleted(bill, customerId);
			// 	if (result != null)
			// 	{
			// 		result.CustomerEmail = customerEmail.Trim();
			// 		_rabbitMQProducer.SendOrderMessage(result);
			// 		var data = _rabbitMQProducer.ReadMessage(_logger);
			// 		if (data.Count() > 0)
			// 		{
			// 			await _documentService.GenerateInvoiceDocxAsync(data.ToList());
			//
			// 			return Ok("Saved Successfully");
			// 		}
			// 		else
			// 		{
			// 			return BadRequest("Issue with RabbitMQ Read Message. Try Again");
			// 		}
			// 	}
			// 	else
			// 	{
			// 		return BadRequest("Order is Invalid");
			// 	}
			// }
			// catch (Exception e)
			// {
			// 	return BadRequest(e);
			// }
			return Ok("todo");
		}
	}
}

