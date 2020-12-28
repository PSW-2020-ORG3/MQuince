using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing
{
    public class CancelAppointmentTest
    {
        private readonly IWebDriver driver;
        private PatientAppointmentsPage patientAppointmentsPage;
        private int patientAppointmentsCount = 0;

        public CancelAppointmentTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            patientAppointmentsPage = new PatientAppointmentsPage(driver);
            patientAppointmentsPage.Navigate();
            patientAppointmentsPage.EnsurePageIsDisplayed();
            patientAppointmentsCount = patientAppointmentsPage.PatientAppointmentsCount();
            Assert.Equal(driver.Url, PatientAppointmentsPage.URI);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestSuccessfulCancelAppointment()
        {
            if (patientAppointmentsPage.IsCancelAppointmentButtonNull())
            {
                Assert.True(true);
                return;
            }
            patientAppointmentsPage.ClickCancelAppointmentButton();

            PatientAppointmentsPage newPatientAppointmentsPage = new PatientAppointmentsPage(driver);
            newPatientAppointmentsPage.Navigate();
            newPatientAppointmentsPage.EnsurePageIsDisplayed();

            Assert.Equal(patientAppointmentsCount - 1, newPatientAppointmentsPage.PatientAppointmentsCount());
        }
    }
}
