using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLab3
{
    public class LoginPage
    {
        By usernameLocator = By.Id("username");
        By passwordLocator = By.Id("passwd");
        By loginButtonLocator = By.Id("login");

        private IWebDriver driver = new ChromeDriver();


        public LoginPage typeUsername(String username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public LoginPage typePassword(String password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public LoginPage submitLogin()
        {
            driver.FindElement(loginButtonLocator).Submit();
            return new LoginPage();
        }

        public LoginPage submitLoginExpectingFailure()
        {
            driver.FindElement(loginButtonLocator).Submit();
            return new LoginPage();
        }

        public LoginPage loginAs(String username, String password)
        {
            typeUsername(username);
            typePassword(password);
            return submitLogin();
        }
    }
}
