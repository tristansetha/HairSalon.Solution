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
            Stylist newStylist = new Stylist("John", "John likes apples");
            newStylist.Save();
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetId_ReturnsStylistId_Int()
        {
            Stylist newStylist = new Stylist("John", "John likes apples");
            int result = newStylist.GetId();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {
            Stylist newStylist = new Stylist("John", "John likes apples");
            newStylist.Save();
            Stylist savedStylist = Stylist.GetAll()[0];
            int result = savedStylist.GetId();
            int testId = newStylist.GetId();
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
        {
            Stylist firstStylist = new Stylist("John", "John likes apples");
            Stylist secondStylist = new Stylist("John", "John likes apples");
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void GetName_ReturnName_String()
        {
            Stylist newStylist = new Stylist("Amy", "Amy likes apples");
            newStylist.Save();
            string result = newStylist.GetName();
            Assert.AreEqual("Amy", result);
        }
    }
}