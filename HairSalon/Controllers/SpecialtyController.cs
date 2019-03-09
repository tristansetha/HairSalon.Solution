using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")] //test
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/specialties")]
        public ActionResult Create(string specialtyDescription)
        {
            Specialty newSpecialty = new Specialty(specialtyDescription);
            newSpecialty.Save();
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View("Index", allSpecialties);
        }

        [HttpGet("/specialties/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty selectedSpecailty = Specialty.Find(id);
            List<Stylist> specailtiesStylists = selectedSpecailty.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedSpecailty", selectedSpecailty);
            model.Add("specailtiesStylists", specailtiesStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }

        [HttpPost("/specialties/delete")]
        public ActionResult DeleteAll()
        {
            Specialty.ClearAll();
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View("Index", allSpecialties);
        }

        // [HttpPost("/stylists/{stylistId}/specialty/new")]
        // public ActionResult AddStylist(int specialtyId, int stylistId)
        // {
        //     Client client = Client.Find(specialtyId);
        //     Stylist stylist = Stylist.Find(specialtyId);
        //     client.AddStylist(stylist);
        //     return RedirectToAction("Show", new { id = specialtyId });
        // }
    }
}