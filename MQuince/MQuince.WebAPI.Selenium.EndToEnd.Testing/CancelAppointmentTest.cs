using MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing
{
    public class CancelAppointmentTest
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver(@"C:\Web");
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("http://localhost:63424/public/index.html");
        }

        [Test]
        [Obsolete]
        public void Cancel_Appointment()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login();
            loginPage.TypeUsername("patient1");
            loginPage.TypePassword("patient1");
            loginPage.ClickLoginButton();

            HomePage homePage = new HomePage(webDriver);
            homePage.ClickObserveAppointment();

            PatientAppointmentsPage patientAppointmentsPage = new PatientAppointmentsPage(webDriver);

            patientAppointmentsPage.ClickCancelAppointmentButton();
        }

    }
}
