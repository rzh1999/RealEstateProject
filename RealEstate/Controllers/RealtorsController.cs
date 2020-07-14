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
            Realtor realtor = await _context.Realtor.Where(c => c.IdentityUserId == userId).SingleOrDefaultAsync();
            if (realtor == null)
            {
                return RedirectToAction("Create");
            }
            var applicationDbContext = _context.Realtor.Include(r => r.IdentityUser);
            return RedirectToAction("ClientList");
        }

        public async Task<IActionResult> ClientList()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Realtor realtor = _context.Realtor.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (realtor == null)
            {
                return RedirectToAction("Create");
            }
            var applicationDbContext = _context.Client;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ClientDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Where(r => r.ClientId == id).Include(c => c.Realtor)
                .FirstOrDefaultAsync();
            if (client == null)
            {
                return NotFound();
            }

            //client.Realtor = await _context.Realtor.Where(r => r.RealtorId == client.RealtorId).FirstOrDefaultAsync();
            //client.LoanOfficer = await _context.Realtor .Where(r => r.LoanOfficerId == client.LoanOfficerId).FirstOrDefaultAsync();
            //client.ClosingRep = await _context.ClosingRep.Where(r => r.ClosingRepId == client.ClosingRepId).FirstOrDefaultAsync();
            

            return View(client);
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

        public IActionResult GetAllRepresentatives()
        {

            var view = new LoanOfficerClosingRepViewModel()
            {
                LoanOfficers = _context.LoanOfficer.ToList(),
                ClosingReps = _context.ClosingRep.ToList(),
            };

            return View(view);

        }


        // GET: Realtors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Realtors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RealtorId,AgentName,LicenseNumber,FirstName,LastName,CompanyName,EmailAddress,PhoneNumber,IdentityUserId")] Realtor realtor)
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


        public async Task<IActionResult> EditChecklist(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklist.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }
            return View(checklist);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditChecklist(int id, Checklist checklist)
        {
            if (id != checklist.ChecklistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction("ClientDetails", new { id = _context.Client.Where(c => c.ChecklistId == id).FirstOrDefault().ClientId});
            }
            return View(id);
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
