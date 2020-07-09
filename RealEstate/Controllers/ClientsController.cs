using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Clients
        public ActionResult Index(Client client)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                var client1 = _context.Client.Where(c => c.IdentityUserId == userId)
                    .Include(c => c.Address)
                    .Include(C => C.IdentityUser)
                    .FirstOrDefault();
                if (client1 == null)
                {
                    return RedirectToAction("CreateClient");
                }

                return View(client1);
            }
            catch
            {
                return RedirectToAction("CreateClient");
            }
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult CreateClient()
        {
            Client client = new Client();
            return View(client);
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateClient(Client clientmodel, Address address)
        {
            string url = string.Format(
               "https://maps.googleapis.com/maps/api/geocode/json?address={0},+{1},+{2}&key={3}",
               clientmodel.Address.StreetAddress, clientmodel.Address.City, clientmodel.Address.State, ApiKeys.googleApi);

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(jsonResult);

                var results = jObject["results"];
                var latitude = (double)results[0]["geometry"]["location"]["lat"];
                var longitude = (double)results[0]["geometry"]["location"]["lng"];
                address.Latitude = latitude;
                address.Longitude = longitude;

            }
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                clientmodel.IdentityUserId = userId;
                _context.Address.Add(address);
                _context.SaveChanges();
                clientmodel.AddressId = address.AddressId;
                _context.Client.Add(clientmodel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
           }
           catch
           {
             return View();
           }
        }

       

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}