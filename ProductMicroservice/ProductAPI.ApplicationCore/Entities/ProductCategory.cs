using System;
namespace ProductAPI.ApplicationCore.Entities
{
	public class ProductCategory
	{
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public ProductCategory ParentCategory { get; set; }
        public ICollection<ProductCategory> ChildCategories { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryVariation> CategoryVariations { get; set; }
    }
}

