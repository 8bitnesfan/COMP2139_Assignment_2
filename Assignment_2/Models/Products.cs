using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int LowStockThreshold { get; set; }
        public int CategoryId { get; set; }
        
        public int CategoriesCategoryId { get; set; }

        public Categories Categories { get; set; }
        
        public ICollection<Products_Categories> ProductsCategories { get; set; }
        
        public List<Products_Orders> Products_Orders { get; set; }
        
        
        public bool Selected { get; set; } 
        
    }
}