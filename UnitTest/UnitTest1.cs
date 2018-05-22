using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriver;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        const string FIRSTNAME = "Joaquín";
        const string LASTNAME = "Sanchez";

        const string FIRSTNAMEEDIT = "Hulio";
        const string LASTNAMEEDIT = "Baptista";
   
        [TestMethod]
        public void GoToPerson()
        {
            Browser.Go("http://localhost:62245/Person");
            Assert.AreEqual(Browser.H2, "Empleados de Avanade");
        }

        [TestMethod]
        public void CreatePerson()
        {
            Browser.CreatePerson(FIRSTNAME, LASTNAME);

            Browser.SearchPerson(FIRSTNAME, LASTNAME);
            Assert.AreEqual(Browser.FirstName, FIRSTNAME);
            Assert.AreEqual(Browser.FirstLastName, LASTNAME);
        }

        [TestMethod]
        public void EditPerson()
        {
            Browser.EditPerson(FIRSTNAMEEDIT, LASTNAMEEDIT);

            Browser.SearchPerson(FIRSTNAMEEDIT, LASTNAMEEDIT);
            Assert.AreEqual(Browser.FirstName,FIRSTNAMEEDIT);
            Assert.AreEqual(Browser.FirstLastName, LASTNAMEEDIT);
        }

        [TestMethod]
        public void DeletePerson()
        {
            Browser.DeletePerson();

            Browser.SearchPerson(FIRSTNAMEEDIT, LASTNAMEEDIT);
            Assert.AreNotEqual(Browser.FirstName, FIRSTNAMEEDIT);
            Assert.AreNotEqual(Browser.FirstLastName, LASTNAMEEDIT);
        }

    }
}
