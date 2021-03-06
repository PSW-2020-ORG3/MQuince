using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.StaffManagement.Application;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.StaffManagement.Integration.Testing
{
    public class DoctorTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;

        public DoctorTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_all_doctors()
        {
            HttpClient client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJiNzA1NmZjYy00OGZhLTRkZjUtOWU5My0zMzRhYjc1OTVkYWEiLCJyb2xlIjoiUGF0aWVudCIsIm5iZiI6MTYxMDMxMTY3NiwiZXhwIjoxNjQxODQ3Njc2LCJpYXQiOjE2MTAzMTE2NzZ9.3bLgIjzH2hXzPdbRz910Q3Jwk2w-SBNE-WaUVGzk3I8");
            
            HttpResponseMessage response = await client.GetAsync("api/doctor/GetAll");

            Assert.True(this.IsOkOrNotFound(response));
        }

        [Fact]
        public async Task Get_doctor_by_id()
        {
            HttpClient client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJiNzA1NmZjYy00OGZhLTRkZjUtOWU5My0zMzRhYjc1OTVkYWEiLCJyb2xlIjoiUGF0aWVudCIsIm5iZiI6MTYxMDMxMTY3NiwiZXhwIjoxNjQxODQ3Njc2LCJpYXQiOjE2MTAzMTE2NzZ9.3bLgIjzH2hXzPdbRz910Q3Jwk2w-SBNE-WaUVGzk3I8");

            HttpResponseMessage response = await client.GetAsync("api/doctor/0d619cf3-25d6-49b2-b4c4-1f70d3121b32");

            Assert.True(this.IsOkOrNotFound(response));
        }

        [Fact]
        public async Task Get_doctor_by_specializations()
        {
            HttpClient client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJiNzA1NmZjYy00OGZhLTRkZjUtOWU5My0zMzRhYjc1OTVkYWEiLCJyb2xlIjoiUGF0aWVudCIsIm5iZiI6MTYxMDMxMTY3NiwiZXhwIjoxNjQxODQ3Njc2LCJpYXQiOjE2MTAzMTE2NzZ9.3bLgIjzH2hXzPdbRz910Q3Jwk2w-SBNE-WaUVGzk3I8");
            
            HttpResponseMessage response = await client.GetAsync("/api/doctor/specialization/2f3c1c3e-9d67-4a0c-acc0-58f8f1fc4e77");

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
