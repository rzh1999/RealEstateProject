using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Authorize(Roles = "LoanOfficer")]
    public class LoanOfficersController : Controller
    {
        private ApplicationDbContext _context;
        public LoanOfficersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: LoanOfficers
        public ActionResult Index()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var loanOfficer = _context.LoanOfficer.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                if (loanOfficer == null)
                {
                    return RedirectToAction("CreateLoanOfficer");
                }

                return View(loanOfficer);
            }
            catch
            {
                return RedirectToAction("CreateLoanOfficer");
            }
        }

       //Get customers
        public ActionResult GetClientList()
        {
            ClientListModel clientListModel = new ClientListModel();
            var clients = _context.Client.ToList();
            return View(clients);
        }

        // GET: LoanOfficers/Create
        public ActionResult CreateLoanOfficer()
        {
            LoanOfficer loanOfficer = new LoanOfficer();
            return View(loanOfficer);
        }

        // POST: LoanOfficers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoanOfficer(LoanOfficer loanOfficerModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                loanOfficerModel.IdentityUserId = userId;
                _context.LoanOfficer.Add(loanOfficerModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanOfficers/Edit/5
        public ActionResult EditClient(int id)
        {
            var clientToEdit = _context.Client.Where(s => s.ClientId == id).FirstOrDefault();
            return View(clientToEdit);
        }

        // POST: LoanOfficers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(int Id, Client client)
        {
            try
            {
                var clientInDb = _context.Client.Where(s => s.ClientId == Id).Single();
                
                clientInDb.ApprovedAmount = client.ApprovedAmount;
                clientInDb.ApprovalDate = client.ApprovalDate;
                
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanOfficers/Edit/5
        public ActionResult EditClientChecklist(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checklist =  _context.Checklist.Find(id);
            if (checklist == null)
            {
                return NotFound();
            }
            return View("EditClientChecklist", checklist);
        }

        // POST: LoanOfficers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClientChecklist(int Id, Checklist checklist)
        {
            if (Id != checklist.ChecklistId)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(checklist);
                    _context.SaveChanges();
                }
                catch 
                {
                return View("EditClientChecklist");
            }
                
           
            return View("EditClientChecklist");
        }


    }
}