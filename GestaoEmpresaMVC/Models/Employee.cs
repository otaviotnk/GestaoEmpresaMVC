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
        [Required(ErrorMessage = "Por favor, informe um nome válido")]
        [DisplayName("Nome")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Por favor, informe um sobrenome válido")]        
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Por favor, informe uma idade")]
        [DisplayName("Idade")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Por favor, selecione o gênero")]
        [DisplayName("Gênero")]
        public string Gender { get; set; }
        [DisplayName("Departamento")]

        public int DepartmentId { get; set; }
        
        [DisplayName("Departamento")]
        public Department Department { get; set; }
        [Required(ErrorMessage = "Por favor, informe um salário válido")]
        [DisplayName("Salário")]
        public double Salary { get; set; }
        [DisplayName("Foto")]

        public string ProfilePicture { get; set; }        
    }
}
