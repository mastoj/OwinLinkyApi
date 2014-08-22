using System.Collections.Generic;

namespace OwinLinkyApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderTotal { get; set; }
    }

    public class OrderDetail
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderTotal { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ItemPrice { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ItemPrice { get; set; }
        public int InStock { get; set; }
    }

    public class IndexModel
    {
        public string WelcomeMessage { get; set; }
    }
}