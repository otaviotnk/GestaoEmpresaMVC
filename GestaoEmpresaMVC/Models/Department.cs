﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresaMVC.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe um nome para o departamento")]
        [DisplayName("Nome do Departamento")]
        public string DepartmentName { get; set; }
    }
}
