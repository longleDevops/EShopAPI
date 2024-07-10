using System;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Models.RequestModels
{
	public class OrderRequestModel
	{
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public decimal BillAmount { get; set; }


        // refer to order status
        public int OrderStatusId { get; set; }
    }
}

