using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Response;

public class ProductResponseModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Product Name is required")]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}