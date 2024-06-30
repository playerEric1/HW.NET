using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ApplicationCore;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Product Name is required")]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string ProductImage { get; set; }
    public int SKU { get; set; }
    public int CategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public List<ProductVariationValue> ProductVariationValues { get; set; }
}

public class ProductCategory
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [Column(TypeName = "varchar(50)")]
    public string CategoryName { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [Column(TypeName = "varchar(150)")]
    public string CategoryDescription { get; set; }
    public int? ParentCategoryId { get; set; }
    public ProductCategory? ParentCategory { get; set; }
    public IEnumerable<ProductCategory>? SubCategories { get; set; }
    public IEnumerable<CategoryVariation> Variations { get; set; }
    public IEnumerable<Product> Products { get; set; }

}

public class CategoryVariation
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string VariationName { get; set; }
    public List<VariationValue> VariationValues { get; set; }
    public ProductCategory Category { get; set; }
}

public class VariationValue
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Value { get; set; }
    public CategoryVariation CategoryVariation { get; set; }
    public List<ProductVariationValue> ProductVariationValues { get; set; }
}

public class ProductVariationValue
{
    public int ProductId { get; set; }
    public int VariationValueId { get; set; }
    public Product Product { get; set; }
    public VariationValue VariationValue { get; set; }
}