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
      Stylist.ClearAll();
      Client.ClearAll();
      Client.ClearJoinTable();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tristan_setha_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("name", 0, "notes");
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }   

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      Client newClient = new Client("Bob",  0, "notes");
      newClient.Save();
      string result = newClient.GetName();
      Assert.AreEqual("Bob", result);
    }

    [TestMethod]
    public void SetName_SetNameAndReturnsCorrectName_String()
    {
      Client newClient = new Client("Bob",  0, "notes");
      newClient.Save();
      newClient.SetName("Tim");
      string result = newClient.GetName();
      Assert.AreEqual("Tim", result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      Client firstClient = new Client("John", 0, "notes");
      Client secondClient = new Client("John", 0, "notes");
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void GetAll_GetAllClientsEmptyList_List()
    {
      Client newClient = new Client("John", 0, "notes");
      newClient.Save();
      int result = Client.GetAll().Count;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToClient_Id()
    {
      Client newClient = new Client("John", 0, "notes");
      newClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = newClient.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClient_Client()
    {
      Client newClient = new Client("Amy", 0, "notes");
      newClient.Save();
      Client foundClient = Client.Find(newClient.GetId());
      Assert.AreEqual(newClient, foundClient);
    }

    [TestMethod]
    public void Edit_ReturnCorrectEdit_String()
    {
      Client testClient = new Client("Walk the Dog", 0, "notes");
      testClient.Save();
      testClient.Edit("newName", 0000000000, "newNotes");
      string result = Client.Find(testClient.GetId()).GetName();
      Assert.AreEqual("newName", result);
    }

    [TestMethod]
    public void GetStylists_ReturnCorrectList_List()
    {
      Stylist newStylist = new Stylist("name", "details");
      newStylist.Save();
      Client newClient = new Client("name", 0, "notes");
      newClient.Save();
      newStylist.AddClient(newClient);
      List<Stylist> test = new List<Stylist> {newStylist};
      List<Stylist> results = newClient.GetStylists();
      CollectionAssert.AreEqual(test, results);
    }

    [TestMethod]
    public void DeleteClient_ReturnsEmptyList_List()
    {
      Client newClient = new Client("name", 0, "notes");
      newClient.Save();
      List<Client> test = new List<Client> {};
      newClient.DeleteClient(newClient.GetId());
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(test, result);
    }

    [TestMethod]
    public void AddStylist_ReturnsCorrectStylist_Stylist()
    {
      Client newClient = new Client("name", 0, "notes");
      newClient.Save();
      Stylist newStylist = new Stylist("name", "details");
      newStylist.Save();
      newClient.AddStylist(newStylist);
      List<Stylist> result = newClient.GetStylists();
      List<Stylist> test = new List<Stylist> {newStylist};
      CollectionAssert.AreEqual(test, result);
    }
  }
}