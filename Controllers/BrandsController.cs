using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.Models;
 

namespace Ecommerce.Controllers
{
    public class BrandsController : Controller
    {
        private readonly EcommerceContext _context;
        public BrandsController(EcommerceContext context)
        {
            _context = context;

        }
        //Get Brands
        public async Task<IActionResult> Index()
        {
            return _context.Brand != null ?
           View(await _context.Brand.ToListAsync()) :
                          Problem("Entity set 'EcommerceContext.Brand'  is null.");
        }

      

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }
        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post : Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Logo")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }
        // Get : Brands/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand.FindAsync(id);
                
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // Post : Brands/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }
        // Get : Brands/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }
        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brand == null)
            {
                return Problem("Entity set 'EcommerceContext.Brand'  is null.");
            }
            var brand = await _context.Brand.FindAsync(id);
            if (brand != null)
            {
                _context.Brand.Remove(brand);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BrandExists(int id)
        {
            return (_context.Brand?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
