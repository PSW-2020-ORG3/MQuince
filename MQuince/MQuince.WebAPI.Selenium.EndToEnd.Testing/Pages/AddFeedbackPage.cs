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
            var txtMessageBox = this.TxtMessageBox();
            Assert.That(txtMessageBox.Displayed);
            Thread.Sleep(1000);
            txtMessageBox.SendKeys(message);
        }

        [Obsolete]
        public void CheckAnonymousCheckBox()
        {
            IWebElement cbForSignAnonymous = webDriver.FindElement(By.Id("Anonymous"));
            Assert.That(cbForSignAnonymous.Displayed);
            cbForSignAnonymous.Click();
        }

        [Obsolete]
        public void ClickSubmitButton()
        {
            var lnkSubmitButton = webDriver.FindElement(By.Id("sendMessageButton"));
            Assert.That(lnkSubmitButton.Displayed);
            lnkSubmitButton.Click();
        }

    }
}
