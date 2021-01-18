using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages
{
    public class AddFeedbackPage
    {
        private IWebDriver webDriver;

        public AddFeedbackPage(IWebDriver _webdriver)
        {
            this.webDriver = _webdriver;
        }

        [Obsolete]
        private IWebElement TxtMessageBox()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name")));
        }


        [Obsolete]
        public void TypeFeedbackMessage(string message)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var el =  wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name")));
            Assert.True(el.Displayed);
            el.SendKeys(message);
        }

        [Obsolete]
        public void CheckAnonymousCheckBox()
        {
            IWebElement cbForSignAnonymous = webDriver.FindElement(By.Id("Anonymous"));
            Assert.That(cbForSignAnonymous.Displayed);
            cbForSignAnonymous.Click();
        }

        public void CheckPrivateCheckBox()
        {
            IWebElement cbForSignPrivate = webDriver.FindElement(By.Id("Private"));
            Assert.That(cbForSignPrivate.Displayed);
            cbForSignPrivate.Click();
        }
        [Obsolete]
        public void ClickSubmitButton()
        {
            var lnkSubmitButton = webDriver.FindElement(By.Id("sendMessageButton"));
            Assert.That(lnkSubmitButton.Displayed);
            lnkSubmitButton.Click();
        }

        [Obsolete]
        public void ClickOkOnAlert()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ExpectedConditions.AlertIsPresent());
            element.Accept();
        }
        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/index.html");
            Assert.IsTrue(webDriver.Url.Equals("https://mquince.herokuapp.com/public/index.html"));
        }

    }
}
