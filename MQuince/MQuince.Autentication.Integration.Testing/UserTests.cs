
using MQuince.Autentication.Contracts.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using MQuince.Autentication.Application;
using System.Net;
using System.Net.Http.Headers;

namespace MQuince.Autentication.Integration.Testing
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
