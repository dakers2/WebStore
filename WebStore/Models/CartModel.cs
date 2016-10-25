using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class CartModel
    {
        public ProductModel[] Products { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal LineTotal { get; set; }
    }
}