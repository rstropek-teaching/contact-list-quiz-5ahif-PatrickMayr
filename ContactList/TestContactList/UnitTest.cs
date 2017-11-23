using ContactList;
using Controllers.ContactList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestContactList
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestGetPerson()
        {
            ContactController controller = new ContactController();

            var erg = (controller.GetPerson("Mayr") as ObjectResult).Value;
            Assert.IsNotNull(erg);
        }

        [TestMethod]
        public void TestGetContactByName()
        {
            ContactController controller = new ContactController();

            var erg = (controller.GetPerson("") as ObjectResult).Value;
            Assert.AreEqual("Invalid lastName", erg);
        }

        [TestMethod]
        public void TestErrorDeletePerson()
        {
            ContactController controller = new ContactController();
       
            var erg = (controller.DeletePerson(-1) as ObjectResult).Value;
            Assert.AreEqual("Invalid index", erg);
        }

        

        
    }
}
