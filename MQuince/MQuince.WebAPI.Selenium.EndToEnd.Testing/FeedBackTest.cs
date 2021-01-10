using MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages;
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
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize(); 
            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/index.html");
        }

        [Test]
        [Obsolete]
        public void Add_Feedback()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login();

            HomePage homePage = new HomePage(webDriver);
            homePage.ClickAddFeedback();

            AddFeedbackPage addFeedbackPage = new AddFeedbackPage(webDriver);
            addFeedbackPage.TypeFeedbackMessage("Some simple text");
            
            addFeedbackPage.CheckAnonymousCheckBox();

            addFeedbackPage.ClickSubmitButton();
        }

    }
}