using System;
namespace ProductAPI.ApplicationCore.Entities
{
	public class VariationValue
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public int VariationId { get; set; }
		public CategoryVariation CategoryVariation { get; set; } = null!;

		public ICollection<ProductVariationValues> ProductOfVariationValues { get; set; } = null!;