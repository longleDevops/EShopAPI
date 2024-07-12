using System;
namespace OrderAPI.ApplicationCore.Models.ResponseModels
{
	public class OrderResponseModel
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public Guid CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public int PaymentMethod { get; set; }
		public string PaymentName { get; set; }
		public string ShippingAddress { get; set; }
		public int ShippingMethod { get; set; }
		public string Shipping { get; set; }
		public decimal BillAmount { get; set; }
		public int OrderStatusId { get; set; }
		public string Order_Status { get; set; }
		
		// public List<OrderResponseModel> OrderDetail { get; set; }
	}
}

