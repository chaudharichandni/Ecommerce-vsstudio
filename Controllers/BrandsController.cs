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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BrandsController(EcommerceContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost]
        public async Task<IActionResult> UploadImage(Models.DB.Brand model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Get the file name and extension
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var extension = Path.GetExtension(fileName);

                    // Generate a unique file name
                    var uniqueFileName = Guid.NewGuid().ToString() + extension;


                    // Set the path where the image will be saved
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", uniqueFileName);

                    // Save the image to the server
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    // Update the model with the image path
                    model.Logo = "/Images/" + uniqueFileName;

                    // Save the updated model to the database


                    var entity = _context.Brand.Find(model.Id);
                    if (entity != null)
                    {
                        // Update the entity with the new image path
                        entity.Logo = model.Logo;

                        // Save changes to the database
                        _context.SaveChanges();
                    }

                }

                // Redirect to the index action after successful upload
                return RedirectToAction("Index");
            }

            // If the model state is invalid, return the view with validation errors
            return View(model);
        }
        private bool BrandExists(int id)
        {
            return (_context.Brand?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
