using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasaMarket.Domain.Entities;
using CasaMarket.Infrastructure.Data;

namespace CasaMarket.API.Controllers
{
    public class ImagesProductsController : Controller
    {
        private readonly CasaMarketApplicationContext _context;

        public ImagesProductsController(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        // GET: ImagesProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImagesProducts.ToListAsync());
        }

        // GET: ImagesProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagesProduct = await _context.ImagesProducts
                .FirstOrDefaultAsync(m => m.ImagesProductID == id);
            if (imagesProduct == null)
            {
                return NotFound();
            }

            return View(imagesProduct);
        }

        // GET: ImagesProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImagesProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImagesProductID,ProductID,ImageUrl")] ImagesProduct imagesProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagesProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagesProduct);
        }

        // GET: ImagesProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagesProduct = await _context.ImagesProducts.FindAsync(id);
            if (imagesProduct == null)
            {
                return NotFound();
            }
            return View(imagesProduct);
        }

        // POST: ImagesProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagesProductID,ProductID,ImageUrl")] ImagesProduct imagesProduct)
        {
            if (id != imagesProduct.ImagesProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagesProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagesProductExists(imagesProduct.ImagesProductID))
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
            return View(imagesProduct);
        }

        // GET: ImagesProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagesProduct = await _context.ImagesProducts
                .FirstOrDefaultAsync(m => m.ImagesProductID == id);
            if (imagesProduct == null)
            {
                return NotFound();
            }

            return View(imagesProduct);
        }

        // POST: ImagesProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagesProduct = await _context.ImagesProducts.FindAsync(id);
            if (imagesProduct != null)
            {
                _context.ImagesProducts.Remove(imagesProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagesProductExists(int id)
        {
            return _context.ImagesProducts.Any(e => e.ImagesProductID == id);
        }
    }
}
