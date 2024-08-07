using System;
namespace OrderAPI.ApplicationCore.Entities
{
	public class OrderDetails
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal Qty { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }

		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}

