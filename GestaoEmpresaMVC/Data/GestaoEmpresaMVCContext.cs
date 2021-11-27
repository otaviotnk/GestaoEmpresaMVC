using GestaoEmpresaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEmpresaMVC.Data
{
    public class GestaoEmpresaMVCContext : DbContext
    {
        public GestaoEmpresaMVCContext(DbContextOptions<GestaoEmpresaMVCContext> options) : base(options) { }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Stock> Stock { get; set; }
    }
}
