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
    public class OrderMastersController : Controller
    {
        private readonly EcommerceContext _context;

        public OrderMastersController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: OrderMasters
        public async Task<IActionResult> Index()
        {
              return _context.OrderMaster != null ? 
                          View(await _context.OrderMaster.ToListAsync()) :
                          Problem("Entity set 'EcommerceContext.OrderMaster'  is null.");
        }

        // GET: OrderMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderMaster == null)
            {
                return NotFound();
            }

            var orderMaster = await _context.OrderMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            return View(orderMaster);
        }

        // GET: OrderMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Order_date,User_id,Order_amount")] OrderMaster orderMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderMaster);
        }

        // GET: OrderMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderMaster == null)
            {
                return NotFound();
            }

            var orderMaster = await _context.OrderMaster.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }
            return View(orderMaster);
        }

        // POST: OrderMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Order_date,User_id,Order_amount")] OrderMaster orderMaster)
        {
            if (id != orderMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderMasterExists(orderMaster.Id))
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
            return View(orderMaster);
        }

        // GET: OrderMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderMaster == null)
            {
                return NotFound();
            }

            var orderMaster = await _context.OrderMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            return View(orderMaster);
        }

        // POST: OrderMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderMaster == null)
            {
                return Problem("Entity set 'EcommerceContext.OrderMaster'  is null.");
            }
            var orderMaster = await _context.OrderMaster.FindAsync(id);
            if (orderMaster != null)
            {
                _context.OrderMaster.Remove(orderMaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderMasterExists(int id)
        {
          return (_context.OrderMaster?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
