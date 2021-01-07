using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;


namespace MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages
{
    public class LoginPage
    {
        private IWebDriver webDriver;

        public LoginPage(IWebDriver _webdriver)
        {
            this.webDriver = _webdriver;
        }

        [Obsolete]
        private IWebElement lnkLogin()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log in")));
        }

        [Obsolete]
        private IWebElement UsernameMessageBox()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
        }


        [Obsolete]
        public void TypeUsername(string username)
        {
            var usernameMessageBox = this.UsernameMessageBox();
            Assert.That(usernameMessageBox.Displayed);
            Thread.Sleep(2000);
            usernameMessageBox.SendKeys(username);
        }

        [Obsolete]
        private IWebElement PasswordMessageBox()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        }


        [Obsolete]
        public void TypePassword(string password)
        {
            var passwordMessageBox = this.PasswordMessageBox();
            Assert.That(passwordMessageBox.Displayed);
            Thread.Sleep(1000);
            passwordMessageBox.SendKeys(password);
        }

        [Obsolete]
        public void ClickLoginButton()
        {
            var lnkLoginButton = webDriver.FindElement(By.Id("sendMessageButton"));
            Assert.That(lnkLoginButton.Displayed);
            lnkLoginButton.Click();
        }

        [Obsolete]
        public void Login()
        {
            this.lnkLogin().Click();
        }
    }
}
