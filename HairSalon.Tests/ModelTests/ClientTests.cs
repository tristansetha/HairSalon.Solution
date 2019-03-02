using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.TestTools
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public void Dispose()
        {
            Client.ClearAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tristan_setha_test;";
        }

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
            Client newClient = new Client("name", 1);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }   

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            Client newClient = new Client("Bob", 1);
            newClient.Save();
            string result = newClient.GetName();
            Assert.AreEqual("Bob", result);
        }

        [TestMethod]
        public void SetName_SetNameAndReturnsCorrectName_String()
        {
            Client newClient = new Client("Bob", 1);
            newClient.Save();
            newClient.SetName("Tim");
            string result = newClient.GetName();
            Assert.AreEqual("Tim", result);
        }

        [TestMethod]
        public void GetStylistId_ReturnsCorrectStylistId_Int()
        {
            Client newClient = new Client("Bob", 0);
            newClient.Save();
            int Id = newClient.GetStylistId();
            Assert.AreEqual(0, Id);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
        {
            Client firstClient = new Client("John", 1);
            Client secondClient = new Client("John", 1);
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void GetAll_GetAllClientsEmptyList_List()
        {
            Client newClient = new Client("John", 1);
            newClient.Save();
            int result = Client.GetAll().Count;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToClient_Id()
        {
            Client newClient = new Client("John", 1);
            newClient.Save();
            Client savedClient = Client.GetAll()[0];
            int result = savedClient.GetId();
            int testId = newClient.GetId();
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectClient_Client()
        {
            Client newClient = new Client("Amy", 1);
            newClient.Save();
            Client foundClient = Client.Find(newClient.GetId());
            Assert.AreEqual(newClient, foundClient);
        }

        [TestMethod]
        public void Edit_ReturnCorrectEdit_String()
        {
        Client testClient = new Client("Walk the Dog", 1);
        testClient.Save();
        testClient.Edit("Mow the lawn");
        string result = Client.Find(testClient.GetId()).GetName();
        Assert.AreEqual("Mow the lawn", result);
        }
    }
}