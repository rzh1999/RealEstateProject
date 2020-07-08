using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class RealtorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealtorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Realtors
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Realtor realtor = _context.Realtor.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (realtor == null)
            {
                return RedirectToAction("Create");
            }
            var applicationDbContext = _context.Realtor.Include(r => r.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Realtors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtor = await _context.Realtor
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.RealtorId == id);
            if (realtor == null)
            {
                return NotFound();
            }

            return View(realtor);
        }

        // GET: Realtors/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Realtors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RealtorId,LicenseNumber,FirstName,LastName,CompanyName,EmailAddress,PhoneNumber,IdentityUserId")] Realtor realtor)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Realtor realtorAlreadyCreated = _context.Realtor.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (realtorAlreadyCreated != null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                realtor.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(realtor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", realtor.IdentityUserId);
            return View(realtor);
        }

        // GET: Realtors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtor = await _context.Realtor.FindAsync(id);
            if (realtor == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", realtor.IdentityUserId);
            return View(realtor);
        }

        // POST: Realtors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RealtorId,LicenseNumber,FirstName,LastName,CompanyName,EmailAddress,PhoneNumber,IdentityUserId")] Realtor realtor)
        {
            if (id != realtor.RealtorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realtor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealtorExists(realtor.RealtorId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", realtor.IdentityUserId);
            return View(realtor);
        }

        // GET: Realtors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtor = await _context.Realtor
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.RealtorId == id);
            if (realtor == null)
            {
                return NotFound();
            }

            return View(realtor);
        }

        // POST: Realtors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realtor = await _context.Realtor.FindAsync(id);
            _context.Realtor.Remove(realtor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealtorExists(int id)
        {
            return _context.Realtor.Any(e => e.RealtorId == id);
        }
    }
}
