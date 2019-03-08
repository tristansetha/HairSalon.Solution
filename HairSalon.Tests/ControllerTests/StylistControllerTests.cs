using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    // [TestClass]
    // public class StylistsControllerTest
    // {
    //     [TestMethod]
    //     public void Index_ReturnsCorrectView_True()
    //     {
    //         StylistsController controller = new StylistsController();
    //         ActionResult indexView = controller.Index();
    //         Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    //     }

    //     [TestMethod]
    //     public void Index_HasCorrectModelType_WordList()
    //     {
    //         StylistsController controller = new StylistsController();
    //         ViewResult indexView = controller.Index() as ViewResult;
    //         var result = indexView.ViewData.Model;
    //         Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    //     }
        
    //     [TestMethod]
    //     public void New_ReturnsCorrectView_True()
    //     {
    //         StylistsController controller = new StylistsController();
    //         ActionResult NewView = controller.New();
    //         Assert.IsInstanceOfType(NewView, typeof(ViewResult));
    //     }

    //     [TestMethod]
    //     public void Create_ReturnsCorrectView_True()
    //     {
    //         StylistsController controller = new StylistsController();
    //         IActionResult view = controller.Create("name", "some details");
    //         Assert.IsInstanceOfType(view, typeof(ViewResult));
    //     }

    //     [TestMethod]
    //     public void Show_ReturnsCorrectView_True()
    //     {
    //         StylistsController controller = new StylistsController();
    //         IActionResult view = controller.Show(0);
    //         Assert.IsInstanceOfType(view, typeof(ViewResult));
    //     }
    // }
}