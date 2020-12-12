using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.WebAPI.Integration.Testing
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

            HttpResponseMessage response = await client.GetAsync("api/specialization");

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }


    }
}
