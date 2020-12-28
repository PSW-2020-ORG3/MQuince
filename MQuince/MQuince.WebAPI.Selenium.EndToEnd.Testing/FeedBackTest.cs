using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

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
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Feedback")));

            Actions action = new Actions(webDriver);
            action.MoveToElement(element).Perform();

            IWebElement lnkAddFeedback = webDriver.FindElement(By.LinkText("Add feedback"));
            lnkAddFeedback.Click();

            IWebElement txtMessageBox = webDriver.FindElement(By.Id("name"));

            Assert.That(txtMessageBox.Displayed);

            txtMessageBox.SendKeys(Keys.Tab);
            txtMessageBox.Clear();
            txtMessageBox.SendKeys("Some Sample Text Here");

            var lnkSubmitButton = webDriver.FindElement(By.Id("sendMessageButton"));

            lnkSubmitButton.Click();
        }
    }
}