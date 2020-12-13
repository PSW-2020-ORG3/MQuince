using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.WebAPI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Newtonsoft.Json;
using MQuince.Services.Contracts.DTO.Appointment;

namespace MQuince.Services.Tests.IntegrationTests
{
    public class AppointmentIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;

        public AppointmentIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Cancel_appointment_status_code_test()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("api/appointment/cancelAppointment/?08d89e6c-7738-434d-8205-4d565c841b97");

            Assert.False(this.IsOkOrNotFound(response));

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
