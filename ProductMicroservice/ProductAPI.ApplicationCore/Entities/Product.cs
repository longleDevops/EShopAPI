using System;
namespace ProductAPI.ApplicationCore.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Qty { get; set; }
		public string ProductImg { get; set; }
		public string SKU { get; set; }

		public int ProductCategoryId { get; set; }
		public ProductCategory ProductCategory { get; set; } = null!;

	}
}

