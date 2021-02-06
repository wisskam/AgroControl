using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroControl.DBContexts;
using AgroControl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AgroControl.Controllers
{
    [Authorize]
    public class GospodarstwoController : Controller
    {
        private readonly GospodarstwoContext _context;
        //private readonly UserManager<AppUser> _userManager;

        public GospodarstwoController(GospodarstwoContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            //_userManager = userManager;
        }

        // GET: Gospodarstwo
        public async Task<IActionResult> Index()
        {
            int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var gospodarstwo = await _context.Gospodarstwo.FirstOrDefaultAsync(x => x.UserID == userID);


            if (gospodarstwo == null)
            {
                return View();
            }
            else
            {
                SetViewBagMessages();
                return View("Details", gospodarstwo);
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

            SetViewBagMessages();
            
            if (gospodarstwo == null)
            {
                return NotFound();
            }

            return View(gospodarstwo);
        }

        // GET: Gospodarstwo/Create
        public async Task<IActionResult> Create()
        {
            using (_context)
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var gospodarstwo = await _context.Gospodarstwo.FirstOrDefaultAsync(x => x.UserID == userID);

                if (gospodarstwo != null)
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
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                gospodarstwo.UserID = userID;

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

        private void SetViewBagMessages()
        {
            ViewBag.Message += TempData["Message"];
            ViewBag.MessageType += TempData["MessageType"];
        }
    }
}
