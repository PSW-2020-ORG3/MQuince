using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.WebAPI.Integration.Testing
{
    public class AppointmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;

        public AppointmentTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_all_appointments()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/Appointment/");

            Assert.True(this.IsOkOrNotFound(response));
        }

        [Fact]
        public async Task Get_appointment_by_id()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("api/Appointment/08d89eab-3c86-487d-8daf-2a7ab50be174");

            Assert.True(this.IsOkOrNotFound(response));
        }

        [Fact]
        public async Task Get_free_appointments()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/Appointment/GetFreeApp/?patientId=6459c216-1770-41eb-a56a-7f4524728546&doctorId=6dd84745-8fcb-4a4b-84da-fe215ebd2f85&date=2020-12-14");

            Assert.True(this.IsOkOrNotFound(response));
        }

        [Fact]
        public async Task Get_for_patient()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/Appointment/GetForPatient/?patientId=6459c216-1770-41eb-a56a-7f4524728546");

            Assert.True(this.IsOkOrNotFound(response));
        }

        private bool IsOkOrNotFound(HttpResponseMessage response)
        {
            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return true;
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return true;

            return false;
        }

    }
}
