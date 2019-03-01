using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
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
            Stylist newStylist = new Stylist(stylistName, stylistDetails, 1);
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        // [HttpGet("/categories/{id}")]
        // public ActionResult Show(int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Stylist selectedStylist = Stylist.Find(id);
        //     List<Stylist> stylistClients = selectedStylist.GetClients();
        //     model.Add("stylist", selectedStylist);
        //     model.Add("clients", stylistClients);
        //     return View(model);
        // }
    }
}