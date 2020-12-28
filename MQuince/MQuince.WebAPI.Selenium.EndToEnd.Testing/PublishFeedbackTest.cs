using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing
{
    public class PublishFeedbackTest
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/index.html");
        }

        [Test]
        [Obsolete]
        public void Publish_Feedback()
        {
            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/Communication/AdminFeedback.html");

            IWebElement feedback = webDriver.FindElement(By.Id("feedbackOption"));
            feedback.Click();

            IWebElement pending = webDriver.FindElement(By.XPath("//select[@name='feedbackOption']/option[text()='Pending']"));
            Assert.That(pending.Displayed, Is.True);
            pending.Click();
            Assert.That(pending.Selected, Is.True);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='btn']")));
            IWebElement button = webDriver.FindElement(By.CssSelector("button[class='btn']"));
            Assert.That(button.Displayed, Is.True);
            button.Click();
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.AlertIsPresent());
                IAlert alert = webDriver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (Exception e)
            {
                //exception handling
            }
        }
    }
}
