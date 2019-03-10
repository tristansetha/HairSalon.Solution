using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_WordList()
        {
            StylistsController controller = new StylistsController();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }
        
        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult NewView = controller.New();
            Assert.IsInstanceOfType(NewView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            IActionResult view = controller.Create("name", "some details");
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            IActionResult view = controller.Show(0);
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void AddClient_RedirectsToCorrectAction_Show()
        {
            StylistsController controller = new StylistsController();
            RedirectToActionResult actionResult = controller.AddClient(0, 0) as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Show", result);
        }

        [TestMethod]
        public void AddSpecialty_RedirectsToCorrectAction_Show()
        {
            StylistsController controller = new StylistsController();
            RedirectToActionResult actionResult = controller.AddSpecialty(0, 0) as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Show", result);
        }

        [TestMethod]
        public void ClearAll_RedirectsToCorrectAction_Show()
        {
            StylistsController controller = new StylistsController();
            RedirectToActionResult actionResult = controller.ClearAll() as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Index", result);
        }

        [TestMethod]
        public void DeleteStylist_RedirectsToCorrectAction_Show()
        {
            StylistsController controller = new StylistsController();
            RedirectToActionResult actionResult = controller.DeleteStylist(0) as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Index", result);
        }

        [TestMethod]
        public void Edit_ReturnsCorrectModelType_Dictionary()
        {
            StylistsController controller = new StylistsController();
            ViewResult editView = controller.Edit(0) as ViewResult;
            var result = editView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void Update_ReturnsCorrectModelType_Dictionary()
        {
            StylistsController controller = new StylistsController();
            ViewResult editView = controller.Update(0, "string", "string") as ViewResult;
            var result = editView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void DeleteClient_RedirectsToCorrectAction_Show()
        {
            StylistsController controller = new StylistsController();
            RedirectToActionResult actionResult = controller.DeleteClient(0) as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Show", result);
        }
    }
}