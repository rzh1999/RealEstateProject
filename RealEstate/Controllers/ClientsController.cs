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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate.Data;
using RealEstate.Models;
using RestSharp;

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
                    .Include(c => c.IdentityUser)
                    .Include(c => c.Checklist)
                    .Include(c => c.Address.PropertyInfo)
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
            ViewBag.AgentName = new SelectList(_context.Realtor, "RealtorId", "AgentName");

            return View(client);
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateClient(Client clientModel, Address address, Checklist checklist, Realtor realtor, PropertyInfo propertyInfo)
        {
            string url = string.Format(
               "https://maps.googleapis.com/maps/api/geocode/json?address={0},+{1},+{2}&key={3}",
               clientModel.Address.StreetAddress, clientModel.Address.City, clientModel.Address.State, ApiKeys.googleApi);

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(jsonResult);

                var results = jObject["results"];
                var latitude = (double)results[0]["geometry"]["location"]["lat"];
                var longitude = (double)results[0]["geometry"]["location"]["lng"];
                clientModel.Address.Latitude = latitude;
                clientModel.Address.Longitude = longitude;

            }

            var client = new RestClient($"https://realtor.p.rapidapi.com/locations/auto-complete?input={clientModel.Address.StreetAddress}+{clientModel.Address.City}+{clientModel.Address.State}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "realtor.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", ApiKeys.realtorApi);
            IRestResponse restResponse = client.Execute(request);
            var jsonRestResult = restResponse.Content;

            if (restResponse.IsSuccessful)
            {
                JObject jObject = JObject.Parse(jsonRestResult);
                var results = jObject["autocomplete"][0]["mpr_id"];
                clientModel.Address.PropertyId = (Int64)results;
            }

            _context.PropertyInfo.Add(propertyInfo);
            _context.SaveChanges();
            clientModel.Address.PropertyInfo = propertyInfo;


            var realtorClient = new RestClient($"https://realtor.p.rapidapi.com/properties/v2/detail?property_id={clientModel.Address.PropertyId}");
            var realtorRequest = new RestRequest(Method.GET);
            realtorRequest.AddHeader("x-rapidapi-host", "realtor.p.rapidapi.com");
            realtorRequest.AddHeader("x-rapidapi-key", ApiKeys.realtorApi);
            IRestResponse realtorResponse = realtorClient.Execute(realtorRequest);
            var jsonRealtorResult = realtorResponse.Content;

            if (realtorResponse.IsSuccessful)
            {
                JObject jObject = JObject.Parse(jsonRealtorResult);
                clientModel.Address.PropertyInfo.Beds = (int)jObject["properties"][0]["beds"];
                clientModel.Address.PropertyInfo.SquareFeet = (int)jObject["properties"][0]["building_size"]["size"];
                clientModel.Address.PropertyInfo.Baths = (int)jObject["properties"][0]["baths"];
                clientModel.Address.PropertyInfo.Price = (double)jObject["properties"][0]["price"];
            }


            try
           {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                clientModel.IdentityUserId = userId;
                checklist.DepositPaid = false;
                checklist.IsApproved = false;
                checklist.IsOfferMade = false;
                checklist.IsInspected = false;
                checklist.IsUnderContract = false;
                checklist.IsClearToClose = false;
                checklist.IsClosed = false;
                _context.Checklist.Add(checklist);
                _context.SaveChanges();
                clientModel.ChecklistId = checklist.ChecklistId;
                //ViewBag.AgentName = new SelectList(_context.Realtor, "RealtorId", "AgentName");


                //save changes after adding checklist
                //then add checklistid to client
                _context.Client.Add(clientModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
           }

            catch (Exception ex)
            {
                ex.ToString();
                return View();
            }

        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction("Index");
            }

            return View(client);
        }



    }
}