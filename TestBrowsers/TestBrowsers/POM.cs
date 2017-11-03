using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestBrowsers
{ 
    public class POM
    {
        By mock = By.Id("MOCK");
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

        IWebDriver driver;
        public POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(string s)
        {
            IWebElement flag = null;
            switch (s)
            {
                case "create":
                    flag = driver.FindElement(create);
                    break;
                case "readJSON":
                    flag = driver.FindElement(readJSON);
                    break;
                case "readXML":
                    flag = driver.FindElement(readXML);
                    break;
                case "readXSLT":
                    flag = driver.FindElement(readXSLT);
                    break;
                case "readHTML":
                    flag = driver.FindElement(readHTML);
                    break;
                case "update":
                    flag = driver.FindElement(update);
                    break;
                case "delete":
                    flag = driver.FindElement(delete);
                    break;
                case "table":
                    flag = driver.FindElement(table);
                    break;
                case "id":
                    flag = driver.FindElement(id);
                    break;
                case "fn":
                    flag = driver.FindElement(fn);
                    break;
                case "ln":
                    flag = driver.FindElement(ln);
                    break;
                case "age":
                    flag = driver.FindElement(age);
                    break;
                case "mock":
                    flag = driver.FindElement(mock);
                    break;
            }
            return flag;
            return driver.FindElement((By)GetType().GetField(s).GetValue(this));
        }
    }    
}

