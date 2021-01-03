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

        [Obsolete]
        private IWebElement lnkLogin()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log in")));
        }

        [Obsolete]
        public void Login()
        {
            this.lnkLogin().Click();
        }
    }
}
