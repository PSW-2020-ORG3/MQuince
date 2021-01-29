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
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            webDriver = new ChromeDriver(options);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("http://localhost:5000/public/index.html");
            //webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/index.html");
        }

        [Test]
        [Obsolete]
        public void Add_Feedback()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Navigate();
            loginPage.TypeUsername("patient2");
            loginPage.TypePassword("patient2");
            loginPage.ClickLogin();

            HomePage homePage = new HomePage(webDriver);
            homePage.ClickAddFeedback();

            AddFeedbackPage addFeedbackPage = new AddFeedbackPage(webDriver);

            addFeedbackPage.TypeFeedbackMessage("Some simple text");
            
            addFeedbackPage.CheckAnonymousCheckBox();

            addFeedbackPage.CheckPrivateCheckBox();

            addFeedbackPage.ClickSubmitButton();

            addFeedbackPage.ClickOkOnAlert();

            addFeedbackPage.NavigateToHomePage();
        }

        [Test]
        [Obsolete]
        public void Publish_Feedback()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Navigate();
            loginPage.TypeUsername("admin");
            loginPage.TypePassword("admin");
            loginPage.ClickLogin();

            PublishFeedbackPage publishFeedbackPage = new PublishFeedbackPage(webDriver);
            publishFeedbackPage.FindOptionForPublishFeedback();
            publishFeedbackPage.SelectOptionForPublishFeedback();
            publishFeedbackPage.SubmitFeedbackForPublish();
            publishFeedbackPage.ClickOkOnAlert();
            publishFeedbackPage.NavigateToHomePage();
        }
    }
}