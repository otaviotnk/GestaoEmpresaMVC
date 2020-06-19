using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Por favor, informe um nome válido")]
        public string FirstName { get; set; }

        [DisplayName("Sobrenome")]
        [Required(ErrorMessage = "Por favor, informe um sobrenome válido")]
        public string LastName { get; set; }

        [DisplayName("Idade")]
        [Required(ErrorMessage = "Por favor, informe uma idade")]
        [Range(15, 99, ErrorMessage = "Por favor, Informe uma idade válida!")]
        public int Age { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "Por favor, selecione o sexo")]
        public string Gender { get; set; }

        [DisplayName("Departamento")]
        public int DepartmentId { get; set; }

        [DisplayName("Departamento")]
        public Department Department { get; set; }

        [DisplayName("Salário")]
        [Required(ErrorMessage = "Por favor, informe um salário válido")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Salary { get; set; }

        [DisplayName("Foto")]
        public string ProfilePicture { get; set; }
    }
}
