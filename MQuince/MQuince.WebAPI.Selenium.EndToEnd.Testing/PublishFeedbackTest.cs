using MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages;
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
            PublishFeedbackPage publishFeedbackPage = new PublishFeedbackPage(webDriver);

            webDriver.Navigate().GoToUrl("https://mquince.herokuapp.com/public/Communication/AdminFeedback.html");

            publishFeedbackPage.FindOptionForPublishFeedback();
            publishFeedbackPage.SelectOptionForPublishFeedback();
            publishFeedbackPage.FindFeedbackForPublish();
            publishFeedbackPage.SubmitFeedbackForPublish();
            /*try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.AlertIsPresent());
                IAlert alert = webDriver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (Exception e)
            {
                //exception handling
            }*/
        }
    }
}
