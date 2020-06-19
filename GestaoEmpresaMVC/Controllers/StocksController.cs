using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoEmpresaMVC.Data;
using GestaoEmpresaMVC.Models;

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
        public async Task<IActionResult> AddRemoveProduct([Bind("Id,ProductId,Quantity,Price")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                int quantityChange = stock.Quantity;
                decimal priceChange = stock.Price;                

                var prod = _context.Product.Where(p => p.Id == stock.ProductId).FirstOrDefault();                

                if (quantityChange != 0)
                {
                    prod.ProductQuantity += quantityChange;
                }
                if (priceChange != 0)
                {
                    prod.ProductPrice = priceChange;
                }               


                if (prod.ProductQuantity >= 0)
                {
                    _context.Add(stock);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Products");
                }
                ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
                return PartialView(stock);

            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
            return PartialView(stock);
        }















        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var gestaoEmpresaMVCContext = _context.Stock.Include(s => s.Product);
            return View(await gestaoEmpresaMVCContext.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity,Price")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", stock.ProductId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", stock.ProductId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,Price")] Stock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", stock.ProductId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.Id == id);
        }
    }
}
