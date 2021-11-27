using GestaoEmpresaMVC.Data;
using GestaoEmpresaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Controllers
{
    public class SalesController : Controller
    {
        private readonly GestaoEmpresaMVCContext _context;

        public SalesController(GestaoEmpresaMVCContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var sales = await _context.Sale.Include(s => s.Client).Include(s => s.Employe).Include(s => s.Product).ToListAsync();
            return View(sales);
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Client)
                .Include(s => s.Employe)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Cpf");
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
            return View();
        }


        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SaleTime,EmployeeId,ProductId,ClientId, Quantity, TotalAmount")] Sale sale)
        {

            if (ModelState.IsValid)
            {
                //Subtrai a quantidade do produto em estoque
                var saleQuantity = sale.Quantity;
                var prod = _context.Product.Where(p => p.Id == sale.ProductId).FirstOrDefault();
                if (saleQuantity <= prod.ProductQuantity)
                {
                    prod.ProductQuantity -= saleQuantity;
                    sale.TotalAmount = prod.ProductPrice * saleQuantity;

                    _context.Add(sale);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "A quantidade do pedido excede a quantidade em estoque");
            }

            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Cpf", sale.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", sale.EmployeeId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", sale.ProductId);
            return View(sale);
        }


        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Address", sale.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", sale.EmployeeId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", sale.ProductId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaleTime,EmployeeId,ProductId,ClientId")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Address", sale.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "FirstName", sale.EmployeeId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Client)
                .Include(s => s.Employe)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sale.FindAsync(id);

            var saleQuantity = sale.Quantity;
            var prod = _context.Product.Where(p => p.Id == sale.ProductId).FirstOrDefault();
            prod.ProductQuantity += saleQuantity;

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}
