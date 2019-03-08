using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.TestTools
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.ClearAll();
            Client.ClearAll();
            Stylist.ClearJoinTable();
            Specialty.ClearAll();
            Specialty.ClearJoinTable();
        }

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tristan_setha_test;";
        }
        [TestMethod]
        public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
        {
            Specialty newSpecialty = new Specialty("description");
            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        } 

        [TestMethod]
        public void GetDescription_ReturnDescription_String()
        {
            Specialty newSpecialty = new Specialty("a description");
            newSpecialty.Save();
            string result = newSpecialty.GetDescription();
            Assert.AreEqual("a description", result);
        }  

        [TestMethod]
        public void GetAll_GetAllSpecialtiesEmptyList_List()
        {
            Specialty newSpecialty = new Specialty("description");
            newSpecialty.Save();
            int result = Specialty.GetAll().Count;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetStylists_GetAllSpecialtyStylistsEmptyList_StylistList()
        {
            Specialty newSpecialty = new Specialty("description");
            newSpecialty.Save();
            List<Stylist> newStylistList = new List<Stylist> {};
            List<Stylist> result = newSpecialty.GetStylists();
            CollectionAssert.AreEqual(newStylistList, result);
        }

        [TestMethod]
        public void AddStylist_ReturnCorrectStylistFromSpecialty_Stylist()
        {
            Specialty newSpecialty = new Specialty("description");
            newSpecialty.Save();
            Stylist newStylist = new Stylist("name", "details");
            newStylist.Save();
            newSpecialty.AddStylist(newStylist);
            List<Stylist> result = newSpecialty.GetStylists();
            List<Stylist> test = new List<Stylist> {newStylist};
            CollectionAssert.AreEqual(test, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectSpecialty_Specialty()
        {
            Specialty newSpecialty = new Specialty("description");
            newSpecialty.Save();
            Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
            Assert.AreEqual(newSpecialty, foundSpecialty);
        }
    }
}