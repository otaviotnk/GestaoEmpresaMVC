using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoEmpresaMVC.Models;

namespace GestaoEmpresaMVC.Data
{
    public class GestaoEmpresaMVCContext : DbContext
    {
        public GestaoEmpresaMVCContext (DbContextOptions<GestaoEmpresaMVCContext> options)
            : base(options)
        {
        }       

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<GestaoEmpresaMVC.Models.TypeProduct> TypeProduct { get; set; }

        public DbSet<GestaoEmpresaMVC.Models.Product> Product { get; set; }

    }
}
