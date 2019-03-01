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
            return View();
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }


    }
}