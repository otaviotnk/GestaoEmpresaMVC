using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresaMVC.Models
{
    public class Sale
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Data/Hora")]
        public DateTime SaleTime { get; set; }

        [DisplayName("Vendedor")]
        public int EmployeeId { get; set; }

        [DisplayName("Vendedor")]
        public Employee Employe { get; set; }

        [DisplayName("Produto")]
        public int ProductId { get; set; }

        [DisplayName("Produto")]
        public Product Product { get; set; }

        [DisplayName("Cliente")]
        public int ClientId { get; set; }

        [DisplayName("Cliente")]
        public Client Client { get; set; }

        [DisplayName("Quantidade")]
        public int Quantity { get; set; }

        [DisplayName("Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalAmount { get; set; }
    }
}
