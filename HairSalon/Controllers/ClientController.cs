using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("clients", client);
            model.Add("stylists", stylist);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Update(int stylistId, int clientId, string newName)
        {
            Client client = Client.Find(clientId);
            client.Edit(newName);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylists", stylist);
            model.Add("clients", client);
            return View("Show", model);
        }

        [HttpPost("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return View();
        }

        // [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
        // public ActionResult Edit(int stylistId, int clientId)
        // {
        // Dictionary<string, object> model = new Dictionary<string, object>();
        // Stylist stylist = Stylist.Find(stylistId);
        // Client client = Client.Find(clientId);
        // model.Add("stylist", stylist);
        // model.Add("client", client);
        // return View(model);
        // }

        // [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
        // public ActionResult Delete(int stylistId, int clientId)
        // {
        //     Stylist.DeleteAllClients(stylistId);
        //     Stylist.Delete(stylistId);

        // return RedirectToAction("Index");
        // }

    }
}