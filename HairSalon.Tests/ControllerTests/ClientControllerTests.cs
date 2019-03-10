using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.New();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsModelType_Dictionary()
        {
            ClientsController controller = new ClientsController();
            ViewResult showView = controller.Show(0) as ViewResult;
            var result = showView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void DeleteAll_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.DeleteAll();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Edit_ReturnsCorrectModelType_Dictionary()
        {
            ClientsController controller = new ClientsController();
            ViewResult editView = controller.Edit(0,0) as ViewResult;
            var result = editView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void DeleteClient_RedirectsToCorrectAction_Index()
        {
            ClientsController controller = new ClientsController();
            RedirectToActionResult actionResult = controller.DeleteClient(0) as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Index", result);
        }
        

        [TestMethod]
        public void AddStylist_RedirectsToCorrectAction_Show()
        {
            ClientsController controller = new ClientsController();
            RedirectToActionResult actionResult = controller.AddStylist(0, 0) as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual("Show", result);
        }
    }
}