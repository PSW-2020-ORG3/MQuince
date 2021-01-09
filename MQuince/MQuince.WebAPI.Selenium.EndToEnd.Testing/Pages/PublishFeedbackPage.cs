﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages
{
    public class PublishFeedbackPage
    {
        private IWebDriver webDriver;

        public PublishFeedbackPage(IWebDriver _webdriver)
        {
            this.webDriver = _webdriver;
        }

        [Obsolete]
        public void FindOptionForPublishFeedback()
        {
            this.WaitForOptionForPublishFeedback();
            IWebElement feedback = webDriver.FindElement(By.Id("feedbackOption"));
            Assert.That(feedback.Displayed, Is.True);
            feedback.Click();
        }

        [Obsolete]
        public void WaitForOptionForPublishFeedback()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("feedbackOption")));
        }

        [Obsolete]
        public void SelectOptionForPublishFeedback()
        {
            this.FindFeedbackForPublish();
            IWebElement pending = webDriver.FindElement(By.XPath("//select[@name='feedbackOption']/option[text()='Pending']"));
            Assert.That(pending.Displayed, Is.True);
            pending.Click();
            Assert.That(pending.Selected, Is.True);
        }

        [Obsolete]
        private void FindSelectOptionForPublishFeedback()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@name='feedbackOption']/option[text()='Pending']")));
        }

        [Obsolete]
        public void FindFeedbackForPublish()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@name='feedbackOption']/option[text()='Pending']")));
        }

        [Obsolete]
        public void SubmitFeedbackForPublish()
        {
            IWebElement button = webDriver.FindElement(By.CssSelector("button[class='btn']"));
            Assert.That(button.Displayed, Is.True);
            button.Click();
        }

    }
}
