using System;
namespace OrderAPI.ApplicationCore.Entities
{
	public class PaymentMethod
	{
		public int Id { get; set; }
		public string Provider { get; set; }
		public int AccountNumber { get; set; }
		public string Expiry { get; set; }
		public bool IsDefault { get; set; }
		public int CustomerId { get; set; }

		public int PaymentTypeId { get; set; }
		public PaymentType PaymentType { get; set; }
	}
}

