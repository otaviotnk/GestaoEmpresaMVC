using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class TypeProduct
    {
        public int Id { get; set; }

        [DisplayName("Nome da Categoria")]
        public string TypeProdName { get; set; }
    }
}
