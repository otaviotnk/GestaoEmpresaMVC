using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome do produto.")]
        [Display(Name = "Produto")]
        public string ProductName { get; set; }

        [Display(Name = "Descrição")]
        public string ProductDescription { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Quantidade")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma categoria.")]
        [Display(Name = "Categoria")]
        public int TypeProductId { get; set; }

        [Display(Name = "Categoria")]
        public TypeProduct TypeProduct { get; set; }         
    }
}
