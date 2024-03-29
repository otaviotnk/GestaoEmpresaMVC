﻿using GestaoEmpresaMVC.Data;
using GestaoEmpresaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Controllers
{
    public class TypeProductsController : Controller
    {
        private readonly GestaoEmpresaMVCContext _context;

        public TypeProductsController(GestaoEmpresaMVCContext context)
        {
            _context = context;
        }

        // GET: TypeProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeProduct.ToListAsync());
        }

        // GET: TypeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            return View(typeProduct);
        }

        // GET: TypeProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeProdName")] TypeProduct typeProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProduct);
        }

        // GET: TypeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProduct.FindAsync(id);
            if (typeProduct == null)
            {
                return NotFound();
            }
            return View(typeProduct);
        }

        // POST: TypeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeProdName")] TypeProduct typeProduct)
        {
            if (id != typeProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeProductExists(typeProduct.Id))
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
            return View(typeProduct);
        }

        // GET: TypeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            return View(typeProduct);
        }

        // POST: TypeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeProduct = await _context.TypeProduct.FindAsync(id);
            _context.TypeProduct.Remove(typeProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeProductExists(int id)
        {
            return _context.TypeProduct.Any(e => e.Id == id);
        }
    }
}
