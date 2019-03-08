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
    }
}