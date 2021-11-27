using GestaoEmpresaMVC.Data;
using GestaoEmpresaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Controllers
{
    public class StocksController : Controller
    {
        private readonly GestaoEmpresaMVCContext _context;

        public StocksController(GestaoEmpresaMVCContext context)
        {
            _context = context;
        }
        public IActionResult AddRemoveProduct()
        {
            ViewData["ProductName"] = new SelectList(_context.Product, "Id", "ProductName");
            ViewData["ProductQuantity"] = new SelectList(_context.Product, "Id", "ProductQuantity");
            ViewData["ProductPrice"] = new SelectList(_context.Product, "Id", "ProductPrice");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> AddRemoveProduct([Bind("Id,ProductId, Quantity, Price")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                int quantityChange = stock.Quantity;
                decimal priceChange = stock.Price;

                var prod = _context.Product.Where(p => p.Id == stock.ProductId).FirstOrDefault();

                //Se algum input foi preenchido
                if (quantityChange != 0 || priceChange > 0)
                {
                    if (quantityChange != 0)
                    {
                        prod.ProductQuantity += quantityChange;
                    }

                    if (priceChange > 0)
                    {
                        prod.ProductPrice = priceChange;
                    }

                    //Se o estoque foi alterado e está > 0
                    if (prod.ProductQuantity >= 0)
                    {
                        _context.Add(stock);
                        await _context.SaveChangesAsync();
                        return Json(true);
                    }
                }
            }
            ViewData["ProductName"] = new SelectList(_context.Product, "Id", "ProductName");
            ViewData["ProductQuantity"] = new SelectList(_context.Product, "Id", "ProductQuantity");
            ViewData["ProductPrice"] = new SelectList(_context.Product, "Id", "ProductPrice");
            return Json(false);

        }

        public async Task<IActionResult> Details(int? id)
        {
            id = 20;
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }
    }
}