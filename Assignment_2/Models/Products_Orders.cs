namespace Assignment_1.Models
{
    public class Products_Orders
    {
        public int OrderId { get; set; }
        public OrdersViewModel OrderViewModel { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}