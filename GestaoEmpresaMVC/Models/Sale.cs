using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Display(Name = "Data/Hora")]
        public DateTime SaleTime { get; set; }

        [Display(Name = "Vendedor")]
        public int EmployeeId { get; set; }

        [Display(Name = "Vendedor")]
        public Employee Employe { get; set; }

        [Display(Name = "Produto")]
        public int ProductId { get; set; }

        [Display(Name = "Produto")]
        public Product Product { get; set; }

        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        [Display(Name = "Cliente")]
        public Client Client { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }

    }
}
