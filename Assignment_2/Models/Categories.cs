using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Products_Categories> ProductsCategories { get; set; }
        
        public ICollection<Products> Products { get; set; }
        
        
    }
}