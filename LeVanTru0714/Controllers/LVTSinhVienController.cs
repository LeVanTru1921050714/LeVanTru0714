using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeVanTru0714.Models;

namespace LeVanTru0714.Controllers
{
    public class LVTSinhVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LVTSinhVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LVTSinhVien
        public async Task<IActionResult> Index()
        {
              return _context.LVTSinhVien != null ? 
                          View(await _context.LVTSinhVien.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LVTSinhVien'  is null.");
        }

        // GET: LVTSinhVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LVTSinhVien == null)
            {
                return NotFound();
            }

            var lVTSinhVien = await _context.LVTSinhVien
                .FirstOrDefaultAsync(m => m.LVTMaSinhVien == id);
            if (lVTSinhVien == null)
            {
                return NotFound();
            }

            return View(lVTSinhVien);
        }

        // GET: LVTSinhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LVTSinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LVTMaSinhVien,LVTTenSinhVien,LVTTuoi")] LVTSinhVien lVTSinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lVTSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lVTSinhVien);
        }

        // GET: LVTSinhVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LVTSinhVien == null)
            {
                return NotFound();
            }

            var lVTSinhVien = await _context.LVTSinhVien.FindAsync(id);
            if (lVTSinhVien == null)
            {
                return NotFound();
            }
            return View(lVTSinhVien);
        }

        // POST: LVTSinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LVTMaSinhVien,LVTTenSinhVien,LVTTuoi")] LVTSinhVien lVTSinhVien)
        {
            if (id != lVTSinhVien.LVTMaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lVTSinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LVTSinhVienExists(lVTSinhVien.LVTMaSinhVien))
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
            return View(lVTSinhVien);
        }

        // GET: LVTSinhVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LVTSinhVien == null)
            {
                return NotFound();
            }

            var lVTSinhVien = await _context.LVTSinhVien
                .FirstOrDefaultAsync(m => m.LVTMaSinhVien == id);
            if (lVTSinhVien == null)
            {
                return NotFound();
            }

            return View(lVTSinhVien);
        }

        // POST: LVTSinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LVTSinhVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LVTSinhVien'  is null.");
            }
            var lVTSinhVien = await _context.LVTSinhVien.FindAsync(id);
            if (lVTSinhVien != null)
            {
                _context.LVTSinhVien.Remove(lVTSinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LVTSinhVienExists(int id)
        {
          return (_context.LVTSinhVien?.Any(e => e.LVTMaSinhVien == id)).GetValueOrDefault();
        }
    }
}
