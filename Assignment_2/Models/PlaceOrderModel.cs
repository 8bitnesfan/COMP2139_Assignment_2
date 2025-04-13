using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class PlaceOrderModel
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        [Required(ErrorMessage = "Shipping address is required.")]
        [StringLength(500, ErrorMessage = "Shipping address cannot exceed 500 characters.")]
        public string ShippingAddress { get; set; }
    }

    public class OrderItem
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}