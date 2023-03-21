using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalPrograming.Models
{
    internal class Order
    {
        public int OrderID { get; set; }
        public int ProductIndex { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public decimal Discount { get; set; }
        public override string ToString()
        {
            return $"OrderID = {OrderID}, ProductIndex = {ProductIndex}, Quantity = {Quantity}, UnitPrice = {UnitPrice}";
        }
        public Order(Order order)
        {
            this.OrderID = order.OrderID ;
            this.ProductIndex = order.ProductIndex ;
            this.Quantity = order.Quantity ;
            this.UnitPrice = order.UnitPrice ;
            this.Discount = order.Discount ;
        }
        public Order()
        {
            
        }
    }
}
