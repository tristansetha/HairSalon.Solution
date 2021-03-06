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
            Client.ClearAll();
            Stylist.ClearJoinTable();
            Specialty.ClearAll();
            Specialty.ClearJoinTable();
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
            Stylist newStylist = new Stylist("Amy", "Amy likes pears");
            newStylist.Save();
            string result = newStylist.GetName();
            Assert.AreEqual("Amy", result);
        }

        [TestMethod]
        public void GetClients_GetAllStylistClientsEmptyList_ClientList()
        {
            Stylist newStylist = new Stylist("Amy", "Amy likes pears");
            newStylist.Save();
            Client newClient = new Client("name", 0, "notes");
            newClient.Save();
            newStylist.AddClient(newClient);
            List<Client> newClientList = new List<Client> {newClient};
            List<Client> result = newStylist.GetClients();
            CollectionAssert.AreEqual(newClientList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectStylist_Stylist()
        {
            Stylist newStylist = new Stylist("Amy", "Amy likes pears");
            newStylist.Save();
            Stylist foundStylist = Stylist.Find(newStylist.GetId());
            Assert.AreEqual(newStylist, foundStylist);
        }

        [TestMethod]
        public void AddSpecialty_AssociatesSpecialtyWithStylist_SpecialtyList()
        {
            Stylist newStylist = new Stylist("name", "details");
            newStylist.Save();
            Specialty newSpecialty = new Specialty("description");
            newSpecialty.Save();
            newStylist.AddSpecialty(newSpecialty);
            List<Specialty> test = new List<Specialty> {newSpecialty};
            List<Specialty> result = newStylist.GetSpecialties();
            CollectionAssert.AreEqual(test, result);
        }

        [TestMethod]
        public void GetSpecialties_GetListOfSpecialtiesFromStylist_Specialty()
        {
            Stylist newStylist = new Stylist("name", "details");
            newStylist.Save();
            Specialty newSpecialty = new Specialty("description");
            newSpecialty.Save();
            newStylist.AddSpecialty(newSpecialty);
            List<Specialty> result = new List<Specialty> {newSpecialty};
            List<Specialty> test = newStylist.GetSpecialties();
            CollectionAssert.AreEqual(test, result);
        }

        [TestMethod]
        public void Edit_ReturnsCorrectEdit_String()
        {
            Stylist testStylist = new Stylist("newName", "newDetails");
            Stylist result = new Stylist("name", "details");
            result.Save();
            result.Edit("newName", "newDetails");
            testStylist.Save();
            Assert.AreEqual(testStylist.GetName(), result.GetName());
        }
        [TestMethod]
        public void AddClient_AssociatesClientWithStylist_ClientList()
        {
            Client newClient = new Client("name", 1, "notes");
            newClient.Save();
            List<Client> test = new List<Client> { newClient };
            Stylist newStylist = new Stylist("name", "details");
            newStylist.Save();
            newStylist.AddClient(newClient);
            List<Client> result = newStylist.GetClients();
            CollectionAssert.AreEqual(test, result);
        }

    }
}