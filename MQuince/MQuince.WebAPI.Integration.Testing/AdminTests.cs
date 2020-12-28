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
    public class AdminTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;

        public AdminTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_all_admins()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/api/Admin/");

            Assert.True(this.IsOkOrNotFound(response));
        }

        [Fact]
        public async Task Get_admin_by_id()
        {
            HttpClient client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("api/Admin/28c51a88-870c-42ce-bf4c-b9ad68126784");

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

        private bool IsOkOrNotFoundOrBadRequest(HttpResponseMessage response)
        {
            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return true;
            if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
                return true;
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return true;

            return false;
        }

    }
}
