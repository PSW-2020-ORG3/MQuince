using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MQuince.WebAPI.Selenium.EndToEnd.Testing.Pages
{
    public class PatientAppointmentsPage
    {
        private IWebDriver webDriver;

        public PatientAppointmentsPage(IWebDriver _webdriver)
        {
            this.webDriver = _webdriver;
        }

        [Obsolete]
        public void ClickCancelAppointmentButton()
        {
            var lnkCancelAppointmentButton = webDriver.FindElement(By.Id("cancelButton"));
            Assert.That(lnkCancelAppointmentButton.Displayed);
            lnkCancelAppointmentButton.Click();
        }
    }
}
