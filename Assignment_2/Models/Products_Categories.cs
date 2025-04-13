using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Products_Categories
    {
        [Key]
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
    }
}