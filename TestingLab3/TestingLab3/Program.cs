using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        IWebDriver webDriver = new ChromeDriver();

        [Test]
        public void MyFirstTest()
        {
            webDriver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/#/");

            Assert.AreEqual("AngularJS • TodoMVC", webDriver.Title);

            //webDriver.Close();

            //webDriver.Quit();
        }

        [Test]
        public void SecondTest()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.typeTask("LAB3 QA");
            homePage.submitTask();

            string check = homePage.todoCount();

            homePage.checkTask();
            homePage.typeTask(check);
            homePage.submitTask();

            //homePage.typeTask("LAB1 QA");
            //homePage.submitTask();

            Assert.AreEqual(check, homePage.todoCount());

            //homePage.Dispose();
        }

        [Test]
        public void ThirdTest()
        {
            HomePage homePage = new HomePage(webDriver);

            string check = homePage.todoCount();
            for (int i = 0; i < 5; i++)
            {
                homePage.typeTask(string.Format("task N{0}", i));
                homePage.submitTask();
            }

            Assert.AreNotEqual(check, homePage.todoCount());

            homePage.Dispose();
        }
    }
}
