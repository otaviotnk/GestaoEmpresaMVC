using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models.ViewModels
{
    public class EmployesViewModel
    {
        public Employee Employee { get; set; }
        public ICollection<Department> Departments { get; set; }
        public IFormFile ProfileImage{ get; set; }
    }
}
