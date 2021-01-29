using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages
{
    public class HomePage
    {
        private IWebDriver webDriver;

        public HomePage(IWebDriver _webdriver)
        {
            this.webDriver = _webdriver;
        }

        [Obsolete]
        private void WaitBeforeShowFeedbackLink()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Observe appointment")));
        }

        [Obsolete]
        private void PerformFeedbackLink()
        {
            this.WaitBeforeShowFeedbackLink();
            IWebElement lnkfeedback = webDriver.FindElement(By.LinkText("Feedback"));
            Assert.That(lnkfeedback.Displayed);
            Actions action = new Actions(webDriver);
            action.MoveToElement(lnkfeedback).Perform();
        }

        [Obsolete]
        public void ClickAddFeedback()
        {
            this.PerformFeedbackLink();

            IWebElement lnkAddFeedback = webDriver.FindElement(By.LinkText("Add feedback"));
            Assert.That(lnkAddFeedback.Displayed);
            lnkAddFeedback.Click();

            Thread.Sleep(500);
        }

    }
}
