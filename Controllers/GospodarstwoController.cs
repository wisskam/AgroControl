using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroControl.DBContexts;
using AgroControl.Models;

namespace AgroControl.Controllers
{
    public class GospodarstwoController : Controller
    {
        private readonly GospodarstwoContext _context;

        public GospodarstwoController(GospodarstwoContext context)
        {
            _context = context;
        }

        // GET: Gospodarstwo
        public async Task<IActionResult> Index()
        {
            if(_context.Gospodarstwo.Count() == 0)
            {
                return View(await _context.Gospodarstwo.ToListAsync());
            }
            else
            {
                return View("Details", _context.Gospodarstwo.First());
            }
        }

        // GET: Gospodarstwo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gospodarstwo gospodarstwo = await _context.Gospodarstwo
                .FirstOrDefaultAsync(m => m.ID == id);


            if (gospodarstwo == null)
            {
                return NotFound();
            }

            return View(gospodarstwo);
        }

        // GET: Gospodarstwo/Create
        public IActionResult Create()
        {
            using (_context)
            {
                var gospodarstwo = _context.Gospodarstwo;
                if(gospodarstwo.Count() >= 1)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // POST: Gospodarstwo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nazwa,Wlasciciel")] Gospodarstwo gospodarstwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gospodarstwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gospodarstwo);
        }

        // GET: Gospodarstwo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gospodarstwo = await _context.Gospodarstwo.FindAsync(id);
            if (gospodarstwo == null)
            {
                return NotFound();
            }
            return View(gospodarstwo);
        }

        // POST: Gospodarstwo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nazwa,Wlasciciel")] Gospodarstwo gospodarstwo)
        {
            if (id != gospodarstwo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gospodarstwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GospodarstwoExists(gospodarstwo.ID))
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
            return View(gospodarstwo);
        }

        // GET: Gospodarstwo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gospodarstwo = await _context.Gospodarstwo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gospodarstwo == null)
            {
                return NotFound();
            }

            return View(gospodarstwo);
        }

        // POST: Gospodarstwo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gospodarstwo = await _context.Gospodarstwo.FindAsync(id);
            _context.Gospodarstwo.Remove(gospodarstwo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GospodarstwoExists(int id)
        {
            return _context.Gospodarstwo.Any(e => e.ID == id);
        }
    }
}
