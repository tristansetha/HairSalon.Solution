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
            List<Client> allClients = Client.GetAll();
            model.Add("stylist", selectedStylist);
            model.Add("stylistClients", stylistClients);
            model.Add("allClients", allClients);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients/new")]
        public ActionResult AddClient(int stylistId, int clientId)
        {
        Stylist stylist = Stylist.Find(stylistId);
        Client client = Client.Find(clientId); // id comes from the select drop down menut
        stylist.AddClient(client);
        return RedirectToAction("Show", new { id = stylistId });
        }

        [HttpPost("/stylists/delete")]
        public ActionResult ClearAll()
        {
            Stylist.ClearAll();
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{stylistId}/delete")]
        public ActionResult DeleteStylist(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            // stylist.DeleteAllClients(stylistId);
            stylist.Delete();
            List<Stylist> allStylists = Stylist.GetAll();
            return RedirectToAction("Index", allStylists);
        } //test

        [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
        public ActionResult DeleteClient(int clientId)
        {
            Client client = Client.Find(clientId);
            client.DeleteClient(clientId);
            List<Client> allClients = Client.GetAll();
            return RedirectToAction("Show", allClients);
        }


        // [HttpPost("/stylists/{stylistId}/clients")]
        // public ActionResult Create(int clientPhoneNumber, string clientName, string clientNotes, int stylistId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Stylist foundStylist = Stylist.Find(stylistId);
        //     Client newClient = new Client(clientName, clientPhoneNumber, clientNotes);
        //     newClient.Save();
        //     foundStylist.AddClient(newClient);
        //     List<Client> stylistClients = foundStylist.GetClients();
        //     model.Add("client", stylistClients);
        //     model.Add("stylist", foundStylist);
        //     return View("Show", model);
        // }

    }
}