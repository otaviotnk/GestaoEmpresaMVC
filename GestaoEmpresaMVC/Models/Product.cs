using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; } 
    }
}
