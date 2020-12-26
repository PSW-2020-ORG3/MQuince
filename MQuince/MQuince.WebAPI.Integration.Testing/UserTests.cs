using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Services.Contracts.DTO.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.WebAPI.Integration.Testing
{
    public class UserTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _factory;

        public UserTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task User_login()
        {
            HttpClient client = _factory.CreateClient();
            LoginDTO appointmentDTO = this.LoginDTO();

            var myContent = JsonConvert.SerializeObject(appointmentDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("/api/User", byteContent);

            Assert.True(this.IsOkOrBadRequest(response));
        }

        private LoginDTO LoginDTO()
            => new LoginDTO()
            {
                Username = "admin",
                Password = "admin"
            };

        private bool IsOkOrBadRequest(HttpResponseMessage response)
        {
            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return true;
            if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
                return true;

            return false;
        }
    }
}
