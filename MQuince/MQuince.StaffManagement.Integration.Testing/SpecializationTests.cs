using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.StaffManagement.Application;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.StaffManagement.Integration.Testing
{
    public class SpecializationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;

        public SpecializationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_all_specializations()
        {
            HttpClient client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJiNzA1NmZjYy00OGZhLTRkZjUtOWU5My0zMzRhYjc1OTVkYWEiLCJyb2xlIjoiUGF0aWVudCIsIm5iZiI6MTYxMDMxMTY3NiwiZXhwIjoxNjQxODQ3Njc2LCJpYXQiOjE2MTAzMTE2NzZ9.3bLgIjzH2hXzPdbRz910Q3Jwk2w-SBNE-WaUVGzk3I8");

            HttpResponseMessage response = await client.GetAsync("api/specialization");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}