using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class OrdersViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public ICollection<Products_Orders> Products_Orders { get; set; }
    }
}