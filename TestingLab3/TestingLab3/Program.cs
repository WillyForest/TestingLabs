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

        //IWebDriver webDriver = new ChromeDriver();

        //[Test]
        //public void MyFirstTest()
        //{
        //    webDriver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/#/");

        //    Assert.AreEqual("AngularJS • TodoMVC", webDriver.Title);

        //    webDriver.Close();

        //    webDriver.Quit();
        //}

        [Test]
        public void SecondTest()
        {
            //webDriver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/#/");

            

            HomePage homePage = new HomePage();


            homePage.typeTask("todo1");
            homePage.submitTask();

            Assert.AreEqual("AngularJS • TodoMVC", homePage.GetTitle());

            homePage.Dispose();
            //webDriver.Close();

            //webDriver.Quit();
        }
    }

}
