using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestBrowsers
{
    [TestFixture(typeof(OperaDriver))]
    public class NUnitTets<TPage> where TPage : IWebDriver, new()
    {
        POM obj;
        static IWebDriver driver = null;
        [OneTimeSetUp]
        public void DriverPath()
        {

            if (typeof(TPage) == typeof(OperaDriver))
            {
                OperaOptions opera = new OperaOptions();
                opera.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";

                driver = new OperaDriver(opera);
            }
            else
            {
                driver = new TPage();
            }
            obj = new POM(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }

        [SetUp]
        public void TestUp()
        {
            driver.Navigate().GoToUrl("http://localhost/Tables/OOP/Table.html");
        }


        By create = By.Id("cre");
        By readJSON = By.Id("rj");
        By readXML = By.Id("rx");
        By readXSLT = By.Id("rs");
        By readHTML = By.Id("rh");
        By update = By.Id("upd");
        By delete = By.Id("del");
        By table = By.Id("tPersons");
        By id = By.Id("Id");
        By fn = By.Id("Fn");
        By ln = By.Id("Ln");
        By age = By.Id("Age");

        [Test]
        [TestCase("create")]
        [TestCase("readJSON")]
        [TestCase("readXML")]
        [TestCase("readXSLT")]
        [TestCase("readHTML")]
        [TestCase("delete")]
        [TestCase("table")]
        [TestCase("id")]
        [TestCase("fn")]
        [TestCase("ln")]
        [TestCase("age")]
        public void TestExistingElements(string elementId)
        {
            IWebElement el = obj.FindElement(elementId);
            NUnit.Framework.Assert.AreEqual(true, el.Displayed);
        }

        [Test]
        [TestCase("1", "A", "B", "12")]
        public void TestCreate(string id, string fn, string ln, string age)
        {
            obj.FindElement("mock").Click();
            obj.FindElement("id").SendKeys(id);
            obj.FindElement("fn").SendKeys(fn);
            obj.FindElement("ln").SendKeys(ln);
            obj.FindElement("age").SendKeys(age);
            obj.FindElement("create").Click();
            obj.FindElement("readJSON").Click();
            IWebElement table_element = obj.FindElement("table");
            IReadOnlyCollection<IWebElement> tr_collection = table_element.FindElements(By.XPath("id('tPersons')/tbody/tr"));


            NUnit.Framework.Assert.AreEqual(1, tr_collection.Count);
            foreach (IWebElement trElement in tr_collection)
            {
                IReadOnlyCollection<IWebElement> td_collection = trElement.FindElements(By.XPath("td"));
                NUnit.Framework.Assert.AreEqual(4, td_collection.Count);
                string[] res = { id, fn, ln, age };
                int count = 0;
                foreach (IWebElement tdElement in td_collection)
                {
                    NUnit.Framework.Assert.AreEqual(res[count++], tdElement.Text);
                }
            }
        }

        [Test]
        [TestCase("1", "A", "B", "12")]
        public void TestDelete(string id, string fn, string ln, string age)
        {
            obj.FindElement("mock").Click();
            obj.FindElement("id").SendKeys(id);
            obj.FindElement("fn").SendKeys(fn);
            obj.FindElement("ln").SendKeys(ln);
            obj.FindElement("age").SendKeys(age);
            obj.FindElement("create").Click();
            obj.FindElement("delete").Click();
            obj.FindElement("readJSON").Click();
            IWebElement table_element = obj.FindElement("table");
            IReadOnlyCollection<IWebElement> tr_collection = table_element.FindElements(By.XPath("id('tPersons')/tbody/tr"));
            NUnit.Framework.Assert.AreEqual(0, tr_collection.Count);
        }

        [Test]
        [TestCase("1", "B", "A", "21")]
        public void TestUpdate(string id, string fn, string ln, string age)
        {
            obj.FindElement("mock").Click();
            obj.FindElement("id").SendKeys(id);
            obj.FindElement("fn").SendKeys("A");
            obj.FindElement("ln").SendKeys("B");
            obj.FindElement("age").SendKeys("12");
            obj.FindElement("create").Click();

            obj.FindElement("fn").Clear();
            obj.FindElement("ln").Clear();
            obj.FindElement("age").Clear();

            obj.FindElement("fn").SendKeys(fn);
            obj.FindElement("ln").SendKeys(ln);
            obj.FindElement("age").SendKeys(age);
            obj.FindElement("update").Click();
            obj.FindElement("readJSON").Click();
            IWebElement table_element = obj.FindElement("table");
            IReadOnlyCollection<IWebElement> tr_collection = table_element.FindElements(By.XPath("id('tPersons')/tbody/tr"));


            NUnit.Framework.Assert.AreEqual(1, tr_collection.Count);
            foreach (IWebElement trElement in tr_collection)
            {
                IReadOnlyCollection<IWebElement> td_collection = trElement.FindElements(By.XPath("td"));
                NUnit.Framework.Assert.AreEqual(4, td_collection.Count);
                string[] res = { id, fn, ln, age };
                int count = 0;
                foreach (IWebElement tdElement in td_collection)
                {
                    NUnit.Framework.Assert.AreEqual(res[count++], tdElement.Text);
                }
            }
        }

        [Test]
        [TestCase("readJSON")]
        [TestCase("readXML")]
        [TestCase("readXSLT")]
        [TestCase("readHTML")]
        public void TestReads(string read)
        {
            obj.FindElement("mock").Click();
            obj.FindElement("id").SendKeys("1");
            obj.FindElement("fn").SendKeys("A");
            obj.FindElement("ln").SendKeys("B");
            obj.FindElement("age").SendKeys("12");
            obj.FindElement("create").Click();
            obj.FindElement(read).Click();
            IWebElement table_element = obj.FindElement("table");
            IReadOnlyCollection<IWebElement> tr_collection = table_element.FindElements(By.XPath("id('tPersons')/tbody/tr"));


            NUnit.Framework.Assert.AreEqual(1, tr_collection.Count);
            foreach (IWebElement trElement in tr_collection)
            {
                IReadOnlyCollection<IWebElement> td_collection = trElement.FindElements(By.XPath("td"));
                NUnit.Framework.Assert.AreEqual(4, td_collection.Count);
                string[] res = { "1", "A", "B", "12" };
                int count = 0;
                foreach (IWebElement tdElement in td_collection)
                {
                    NUnit.Framework.Assert.AreEqual(res[count++], tdElement.Text);
                }
            }
        }
    }
}

