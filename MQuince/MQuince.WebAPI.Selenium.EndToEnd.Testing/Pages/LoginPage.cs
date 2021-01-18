using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages
{
    public class LoginPage
    {
        private IWebDriver webDriver;

        public LoginPage(IWebDriver _webdriver)
        {
            this.webDriver = _webdriver;
        }

        public void Navigate()
        {
            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/Login/Login.html");
        }

        public void TypeUsername(string username)
        {
            IWebElement usernameBox = webDriver.FindElement(By.Id("name"));
            usernameBox.SendKeys(username);
            Assert.True(usernameBox.Displayed);
        }

        public void TypePassword(string password)
        {
            IWebElement usernameBox = webDriver.FindElement(By.Id("password"));
            usernameBox.SendKeys(password);
            Assert.True(usernameBox.Displayed);
        }

        public void ClickLogin()
        {
            IWebElement loginButton = webDriver.FindElement(By.Id("sendMessageButton"));
            Assert.True(loginButton.Displayed);
            loginButton.Click();
        }
    }
}
