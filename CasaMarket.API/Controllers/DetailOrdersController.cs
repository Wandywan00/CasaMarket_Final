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
    public class DetailOrdersController : Controller
    {
        private readonly CasaMarketApplicationContext _context;

        public DetailOrdersController(CasaMarketApplicationContext context)
        {
            _context = context;
        }

        // GET: DetailOrders
        public async Task<IActionResult> Index()
        {
            var casaMarketApplicationContext = _context.DetailOrders.Include(d => d.Order).Include(d => d.Product);
            return View(await casaMarketApplicationContext.ToListAsync());
        }

        // GET: DetailOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrder = await _context.DetailOrders
                .Include(d => d.Order)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DetailOrderID == id);
            if (detailOrder == null)
            {
                return NotFound();
            }

            return View(detailOrder);
        }

        // GET: DetailOrders/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "State");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Category");
            return View();
        }

        // POST: DetailOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailOrderID,OrderID,ProductID")] DetailOrder detailOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "State", detailOrder.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Category", detailOrder.ProductID);
            return View(detailOrder);
        }

        // GET: DetailOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrder = await _context.DetailOrders.FindAsync(id);
            if (detailOrder == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "State", detailOrder.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Category", detailOrder.ProductID);
            return View(detailOrder);
        }

        // POST: DetailOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailOrderID,OrderID,ProductID")] DetailOrder detailOrder)
        {
            if (id != detailOrder.DetailOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailOrderExists(detailOrder.DetailOrderID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "State", detailOrder.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Category", detailOrder.ProductID);
            return View(detailOrder);
        }

        // GET: DetailOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrder = await _context.DetailOrders
                .Include(d => d.Order)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DetailOrderID == id);
            if (detailOrder == null)
            {
                return NotFound();
            }

            return View(detailOrder);
        }

        // POST: DetailOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailOrder = await _context.DetailOrders.FindAsync(id);
            if (detailOrder != null)
            {
                _context.DetailOrders.Remove(detailOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailOrderExists(int id)
        {
            return _context.DetailOrders.Any(e => e.DetailOrderID == id);
        }
    }
}
