using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroControl.DBContexts;
using AgroControl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroControl.Controllers
{
    public class ObiektGospodarczyController : Controller
    {
        private readonly GospodarstwoContext _context;

        public ObiektGospodarczyController(GospodarstwoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obiektGospodarczy = await _context.ObiektyGospodarcze
                .FirstOrDefaultAsync(m => m.ID == id);
            if (obiektGospodarczy == null)
            {
                return NotFound();
            }

            return View(obiektGospodarczy);
        }

        // GET: ObiektGospodarczyController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObiektGospodarczyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nazwa")] ObiektGospodarczy obiektGospodarczy)
        {
            obiektGospodarczy.Gospodarstwo = _context.Gospodarstwo.First();
            obiektGospodarczy.GospodarstwoID = _context.Gospodarstwo.First().ID;
            if (ModelState.IsValid)
            {
                _context.Add(obiektGospodarczy);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Gospodarstwo");
        }

        //// GET: ObiektGospodarczyController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ObiektGospodarczyController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ObiektGospodarczyController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ObiektGospodarczyController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
