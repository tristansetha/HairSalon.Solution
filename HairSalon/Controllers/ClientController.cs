using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")] //test
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/clients/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/clients")]
        public ActionResult Create(string name, int phoneNumber, string notes)
        {
            Client newClient = new Client(name, phoneNumber, notes);
            newClient.Save();
            List<Client> allClients = Client.GetAll();
            return View("Index", allClients);
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client selectedClient = Client.Find(id);
            List<Stylist> clientStylists = selectedClient.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedClient", selectedClient);
            model.Add("clientStylists", clientStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }

        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int categoryId)
        {
        Stylist category = Stylist.Find(categoryId);
        return View(category);
        }

        [HttpPost("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return View();
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            Client client = Client.Find(clientId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View(model);
        }

        [HttpPost("/clients/{clientId}/stylists/new")]
        public ActionResult AddStylist(int clientId, int stylistId)
        {
        Client client = Client.Find(clientId);
        Stylist stylist = Stylist.Find(stylistId);
        client.AddStylist(stylist);
        return RedirectToAction("Show", new { id = clientId });
        }

        // [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
        // public ActionResult Delete(int stylistId, int clientId)
        // {
        //     Stylist.DeleteAllClients(stylistId);
        //     Stylist.Delete(stylistId);

        // return RedirectToAction("Index");
        // }

    }
}