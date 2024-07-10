using System;
namespace OrderAPI.ApplicationCore.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string PaymentMethod { get; set; }
		public string PaymentName { get; set; }
		public string ShippingAddress { get; set; }
		public string ShippingMethod { get; set; }
		public decimal BillAmount { get; set; }

		public ICollection<OrderDetails> OrderDetails { get; set; }

		// refer to order status
		public int OrderStatusId { get; set; }
		public OrderStatus OrderStatus { get; set; }
	}
}

