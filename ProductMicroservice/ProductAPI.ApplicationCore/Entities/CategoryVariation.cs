using System;
namespace ProductAPI.ApplicationCore.Entities
{
	public class CategoryVariation
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int ProductCategoryId { get; set; }
		public ProductCategory ProductCategory { get; set; }

		public ICollection<VariationValue> VariationValues { get; set; }


	}
}

