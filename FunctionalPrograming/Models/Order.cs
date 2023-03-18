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

        public override string ToString()
        {
            return $"OrderID = {OrderID}, ProductIndex = {ProductIndex}, Quantity = {Quantity}, UnitPrice = {UnitPrice}";
        }
    }
}
