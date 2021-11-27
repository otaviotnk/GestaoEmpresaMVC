using System.ComponentModel;

namespace GestaoEmpresaMVC.Models
{
    public class TypeProduct
    {
        public int Id { get; set; }

        [DisplayName("Nome da Categoria")]
        public string TypeProdName { get; set; }
    }
}
