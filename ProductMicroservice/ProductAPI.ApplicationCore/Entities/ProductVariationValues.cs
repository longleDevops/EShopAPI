using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.ApplicationCore.Entities
{
	public class ProductVariationValues
	{
		[Key]
		public int ProductId { get; set; }

		[Key]
		public int VariationValueId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;

        [ForeignKey("VariationValueId")]
        public VariationValue VariationValue { get; set; } = null!;

	}
}

