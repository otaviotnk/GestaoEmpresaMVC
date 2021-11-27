using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresaMVC.Models.ViewModels
{
    public class EmployeesViewModel
    {
        public Employee Employee { get; set; }
        public ICollection<Department> Departments { get; set; }

        [Required(ErrorMessage = "Por favor, escolha uma imagem de perfil")]
        [Display(Name = "Foto de Perfil")]
        public IFormFile ProfileImage { get; set; }
    }
}
