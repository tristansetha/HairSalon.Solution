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
            model.Add("stylist", selectedStylist);
            model.Add("client", stylistClients);
            return View(model);
        }

        //Create new clients within a given stylist
        [HttpPost("/stylists/{stylistId}/clients")]
        public ActionResult Create(int clientPhoneNumber, string clientName, string clientNotes, int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(clientName, clientPhoneNumber, clientNotes);
            newClient.Save();
            foundStylist.AddClient(newClient);
            List<Client> stylistClients = foundStylist.GetClients();
            model.Add("client", stylistClients);
            model.Add("stylist", foundStylist);
            return View("Show", model);
        }

        // [HttpPost("/categories/{categoryId}/items/{itemId}/delete")]
        // public ActionResult DeleteItem(int itemId)
        // {
        //     Item item = Item.Find(itemId);
        //     item.DeleteItem(itemId);
        //     List<Item> allItems = Item.GetAll();
        //     return RedirectToAction("Show", allItems);
        // }

        [HttpPost("/stylists/delete")]
        public ActionResult ClearAll()
        {
            Stylist.ClearAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{stylistId}/delete")]
        public ActionResult Delete(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            // stylist.DeleteAllClients(stylistId);
            stylist.Delete();
            return RedirectToAction("Index");
        } //test
    }
}