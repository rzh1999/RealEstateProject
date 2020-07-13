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
                    .Include(C => C.IdentityUser)
                    .FirstOrDefault();
                if (client1 == null)
                {
                    return RedirectToAction("CreateClient");
                }

                var restClient = new RestClient($"https://realtor.p.rapidapi.com/properties/v2/detail?property_id=${client1.Address.PropertyId}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "realtor.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", ApiKeys.realtorApi);
                IRestResponse restResponse = restClient.Execute(request);
                var jsonRestResult = restResponse.Content;

                if (restResponse.IsSuccessful)
                {
                    JObject jObject = JObject.Parse(jsonRestResult);
                    client1.Address.PropertyInfo.Beds = (int)jObject["meta"]["tracking_params"]["listingBeds"];
                    client1.Address.PropertyInfo.SquareFeet = (int)jObject["meta"]["tracking_params"]["listingSqFt"];
                    client1.Address.PropertyInfo.Baths = (int)jObject["meta"]["tracking_params"]["listingBaths"];
                    client1.Address.PropertyInfo.Price = (double)jObject["meta"]["tracking_params"]["listingPrice"];
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
        public async Task<ActionResult> CreateClient(Client clientmodel, Address address, Checklist checklist, Realtor realtor)
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
                clientmodel.Address.Latitude = latitude;
                clientmodel.Address.Longitude = longitude;

            }

            var client = new RestClient($"https://realtor.p.rapidapi.com/locations/auto-complete?input={clientmodel.Address.StreetAddress}+{clientmodel.Address.City}+{clientmodel.Address.State}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "realtor.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", ApiKeys.realtorApi);
            IRestResponse restResponse = client.Execute(request);
            var jsonRestResult = restResponse.Content;

            if (restResponse.IsSuccessful)
            {
                JObject jObject = JObject.Parse(jsonRestResult);
                var results = jObject["autocomplete"][0]["mpr_id"];
                clientmodel.Address.PropertyId = (Int64)results;
            }


            try
           {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                clientmodel.IdentityUserId = userId;
                //Checklist checklist = new Checklist();

                checklist.DepositPaid = false;
                checklist.IsApproved = false;
                checklist.IsOfferMade = false;
                checklist.IsInspected = false;
                checklist.IsUnderContract = false;
                checklist.IsClearToClose = false;
                checklist.IsClosed = false;
            _context.Checklist.Add(checklist);
            _context.SaveChanges();
            clientmodel.ChecklistId = checklist.ChecklistId;
                 ViewBag.AgentName = new SelectList(_context.Realtor, "RealtorId", "AgentName");
              
                clientmodel.AddressId = address.AddressId;
              
            //save changes after adding checklist
            //then add checklistid to client

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


       
    }
}