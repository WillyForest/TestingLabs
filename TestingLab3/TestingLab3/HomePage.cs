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
        By taskInput = By.XPath("//input");
        By taskForm = By.XPath("//form");
        By checkbox = By.XPath("//div[@class=\"view\"]//input[@type=\"checkbox\"]");
        By tdCount = By.XPath("//span[@class=\"todo-count\"]//strong");

        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/#/");
        }

        public HomePage typeTask(String task)
        {
            Actions builder = new Actions(_driver);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(taskInput));
            myDynamicElement.Clear();
            myDynamicElement.Click();
            myDynamicElement.SendKeys(task);
            return this;
        }

        public HomePage submitTask()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement2 = wait.Until<IWebElement>(d => d.FindElement(taskForm));
            myDynamicElement2.Submit();
            return this;
        }

        public HomePage checkTask()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement2 = wait.Until<IWebElement>(d => d.FindElement(checkbox));
            myDynamicElement2.Click();
            return this;
        }

        public string isChecked()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement2 = wait.Until<IWebElement>(d => d.FindElement(checkbox));
            return myDynamicElement2.GetAttribute("checked");
        }

        public string todoCount()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement2 = wait.Until<IWebElement>(d => d.FindElement(tdCount));
            return myDynamicElement2.Text;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
