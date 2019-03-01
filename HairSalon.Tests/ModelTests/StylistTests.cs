using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.TestTools
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.ClearAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tristan_setha_test;";
        }

        [TestMethod]
        public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
        {
            Stylist newStylist = new Stylist("name", "details", 1);
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }   

        [TestMethod]
        public void GetAll_GetAllStylistsEmptyList_List()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }


    }
}