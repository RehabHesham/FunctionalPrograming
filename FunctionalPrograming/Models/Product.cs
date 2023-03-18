using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalPrograming.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ProductId = {Id}, Name = {Name}, Description = {Description}, ProductType = {Type.ToString()}, Price = {Price} $";
        }
    }
}
