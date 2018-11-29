using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLab3
{
    public class HomePage
    {
        By taskName = By.XPath("//input");//By.XPath(".new-todo");
        By submitTaskLocator = By.XPath("//form");
        //By passwordLocator = By.Id("passwd");
        //By loginButtonLocator = By.Id("login");

        private IWebDriver _driver;

        public HomePage()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/#/");
        }

        public HomePage typeTask(String task)
        {
            Actions builder = new Actions(_driver);
            //WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(30));
            //_driver.FindElement(taskName);

            // element7.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(taskName));
            myDynamicElement.Clear();
            myDynamicElement.Click();
            myDynamicElement.SendKeys(task);
            IWebElement myDynamicElement2 = wait.Until<IWebElement>(d => d.FindElement(submitTaskLocator));
            myDynamicElement2.Submit();
            builder.SendKeys(Keys.Enter);
            myDynamicElement.SendKeys(task);
            builder.SendKeys(Keys.Enter);
            myDynamicElement.SendKeys(task);
            //builder.SendKeys(Keys.Enter);
            //builder.SendKeys(Keys.Tab);
            //builder.SendKeys(Keys.Enter);
            //_driver.FindElement(taskName).SendKeys(task);
            return this;
        }

        public HomePage submitTask()
        {
            //_driver.FindElement(submitTaskLocator).Submit();
            return this;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void Dispose()
        {
            //_driver.Close();
            //_driver.Quit();
        }
    }
}
