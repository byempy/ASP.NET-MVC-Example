using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver
{
    public static class Browser
    {
        public static IWebDriver webDriver = new ChromeDriver();
        public static string Title { get { return webDriver.Title; } }

        public static string H2 {
            get {
                try
                {
                    var h2 = webDriver.FindElement(By.TagName("h2")).Text;
                    return h2;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string FirstName {
            get {
                try
                {
                    var fila = webDriver.FindElements(By.TagName("tr"))[1];
                    var nombre = fila.FindElements(By.TagName("td"))[1].Text;
                    return nombre;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string FirstLastName {
            get {
                try
                {
                    var fila = webDriver.FindElements(By.TagName("tr"))[1];
                    var apellido = fila.FindElements(By.TagName("td"))[2].Text;
                    return apellido;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static void Go(string url)
        {
            webDriver.Url = url;
        }

        public static void SearchPerson(string firtname, string lastname)
        {
            var txtNombre = webDriver.FindElement(By.Name("nombre"));
            txtNombre.SendKeys(firtname);

            var txtApellido = webDriver.FindElement(By.Name("apellido"));
            txtApellido.SendKeys(lastname);

            var formulario = webDriver.FindElement(By.Id("form0"));
            formulario.Submit();

        }

        public static void CreatePerson(string firstname, string lastname)
        {
            webDriver.FindElement(By.LinkText("Create New")).Click();

            webDriver.FindElement(By.Id("FirstName")).SendKeys(firstname);

            webDriver.FindElement(By.Id("LastName")).SendKeys(lastname);

            webDriver.FindElement(By.TagName("form")).Submit();
        }

        public static void DeletePerson()
        {
            webDriver.FindElement(By.LinkText("Delete")).Click();

            webDriver.FindElement(By.TagName("form")).Submit();
        }

        public static void EditPerson(string firstname, string lastname)
        {
            webDriver.FindElement(By.LinkText("Edit")).Click();

            var txtFirstName = webDriver.FindElement(By.Id("FirstName"));
            txtFirstName.Clear();
            txtFirstName.SendKeys(firstname);

            var txtLastName = webDriver.FindElement(By.Id("LastName"));
            txtLastName.Clear();
            txtLastName.SendKeys(lastname);

            webDriver.FindElement(By.TagName("form")).Submit();
        }

        public static void Close()
        {
            webDriver.Close();
        }
    }
}
