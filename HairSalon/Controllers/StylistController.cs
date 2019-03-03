using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string stylistName, string stylistDetails)
        {
            Stylist newStylist = new Stylist(stylistName, stylistDetails);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylists", selectedStylist);
            model.Add("clients", stylistClients);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/delete")]
        public ActionResult Delete(int stylistId)
        {
            
            Stylist stylist = Stylist.Find(stylistId);
            // stylist.DeleteAllClients(stylistId);
            stylist.Delete(stylistId);

            return RedirectToAction("Index");
        } //test

        //Create new clients within a given stylist
        [HttpPost("/stylists/{stylistId}/clients")]
        public ActionResult Create(int stylistId, string clientName)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(clientName, stylistId);
            newClient.Save();
            foundStylist.AddClient(newClient);
            List<Client> stylistClients = foundStylist.GetClients();
            model.Add("clients", stylistClients);
            model.Add("stylists", foundStylist);
            return View("Show", model);
        }
    }
}