﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var gospodarstwo = await _context.Gospodarstwo.FirstOrDefaultAsync(x => x.UserID == userID);

            obiektGospodarczy.Gospodarstwo = gospodarstwo;
            obiektGospodarczy.GospodarstwoID = gospodarstwo.ID;

            if (ModelState.IsValid)
            {
                _context.Add(obiektGospodarczy);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Gospodarstwo");
        }

        //// GET: ObiektGospodarczyController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var obiektGospodarczy = await _context.ObiektyGospodarcze.FindAsync(id);
            if (obiektGospodarczy == null)
            {
                return NotFound();
            }
            return View(obiektGospodarczy);
        }

        //// POST: ObiektGospodarczyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ObiektGospodarczy obiektGospodarczy)
        {
            try
            {
                _context.Update(obiektGospodarczy);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Gospodarstwo");
            }
            catch
            {
                return View();
            }
        }

        // GET: ObiektGospodarczyController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var obiektGospodarczy = await _context.ObiektyGospodarcze
                .FirstOrDefaultAsync(og => og.ID == id);
            if (obiektGospodarczy == null)
            {
                return NotFound();
            }

            _context.ObiektyGospodarcze.Remove(obiektGospodarczy);
            _context.SaveChanges();

            return RedirectToAction("Index", "Gospodarstwo");
        }
    }
}
