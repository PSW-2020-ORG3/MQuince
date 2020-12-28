using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing
{
    public class FeedBackTest
    {
        private IWebDriver webDriver;
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver(@"C:\Web");
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/index.html");
        }

        [Test]
        [Obsolete]
        public void Add_Feedback()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var lnkfeedback = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Feedback")));
            Assert.That(lnkfeedback.Displayed);

            Actions action = new Actions(webDriver);
            action.MoveToElement(lnkfeedback).Perform();

            IWebElement lnkAddFeedback = webDriver.FindElement(By.LinkText("Add feedback"));
            Assert.That(lnkAddFeedback.Displayed);
            lnkAddFeedback.Click();

            Thread.Sleep(1000);

            IWebElement txtMessageBox = webDriver.FindElement(By.Id("name"));
            Assert.That(txtMessageBox.Displayed);

            Thread.Sleep(1000);

            txtMessageBox.SendKeys(Keys.Tab);
            txtMessageBox.Clear();
            txtMessageBox.SendKeys("Some Sample Text Here");

            Thread.Sleep(2000);

            IWebElement cbForSign= webDriver.FindElement(By.Id("Anonymous"));
            Assert.That(cbForSign.Displayed);

            cbForSign.Click();
            Thread.Sleep(1000);


            var lnkSubmitButton = webDriver.FindElement(By.Id("sendMessageButton"));

            lnkSubmitButton.Click();

            Thread.Sleep(1000);
            
        }
    }
}