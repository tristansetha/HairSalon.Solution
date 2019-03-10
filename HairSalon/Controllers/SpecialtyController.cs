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
            Specialty selectedSpecialty = Specialty.Find(id);
            List<Stylist> specailtiesStylists = selectedSpecialty.GetStylists();
            List<Stylist> allStylists = Stylist.GetAll();
            model.Add("selectedSpecialty", selectedSpecialty);
            model.Add("specailtiesStylists", specailtiesStylists);
            model.Add("allStylists", allStylists);
            return View(model);
        }

        [HttpPost("/specialties/{id}/delete")] 
        public ActionResult DeleteSpecialty(int id)
        {
            Specialty selectedSpecialty = Specialty.Find(id);
            selectedSpecialty.DeleteSpecialty(id);
            List<Specialty> allSpecialties = Specialty.GetAll();
            return RedirectToAction("Index", allSpecialties);
        }

        [HttpPost("/specialties/delete")]
        public ActionResult DeleteAll()
        {
            Specialty.ClearAll();
            List<Specialty> allSpecialties = Specialty.GetAll();
            return View("Index", allSpecialties);
        }

        [HttpPost("/specialties/{specialtyId}/stylists/new")] //select option drop down
        public ActionResult AddStylist(int specialtyId, int stylistId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            Stylist stylist = Stylist.Find(stylistId);
            specialty.AddStylist(stylist);
            return RedirectToAction("Show", new { id = specialtyId });
        }
    }
}