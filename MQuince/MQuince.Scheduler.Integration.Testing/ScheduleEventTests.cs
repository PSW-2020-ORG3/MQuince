using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Scheduler.Application;
using MQuince.Scheduler.Contracts.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MQuince.Scheduler.Integration.Testing
{
        public class ScheduleEventTests : IClassFixture<WebApplicationFactory<Startup>>
        {
            WebApplicationFactory<Startup> _factory;

            public ScheduleEventTests(WebApplicationFactory<Startup> factory)
            {
                _factory = factory;
            }

            [Fact]
            public async Task Get_statistics()
            {
                HttpClient client = _factory.CreateClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJiZTgwOWY4My1kNTk5LTQ0ODItYWNlYS0wYTRhNDIyYTQxMWQiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2MTE1MTUwMzgsImV4cCI6MTY0MzA1MTAzOCwiaWF0IjoxNjExNTE1MDM4fQ.JcMOIeU81PwHYB_21jGgJHkHkrjT-q8sYYbZfv7iy-U");

                HttpResponseMessage response = await client.GetAsync("/api/ScheduleEvent/");

                Assert.True(this.IsOkOrNotFound(response));
            }

        [Fact]
        public async Task Create_event()
        {
            HttpClient client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJiNzA1NmZjYy00OGZhLTRkZjUtOWU5My0zMzRhYjc1OTVkYWEiLCJyb2xlIjoiUGF0aWVudCIsIm5iZiI6MTYxMDMxMTY3NiwiZXhwIjoxNjQxODQ3Njc2LCJpYXQiOjE2MTAzMTE2NzZ9.3bLgIjzH2hXzPdbRz910Q3Jwk2w-SBNE-WaUVGzk3I8");
            ScheduleEventDTO scheduleEventDTO = new ScheduleEventDTO()
            {
                SessionId = Guid.NewGuid(),
                EventType = Domain.Events.ScheduleEventType.EXIT
            };

            var myContent = JsonConvert.SerializeObject(scheduleEventDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("/api/ScheduleEvent/", byteContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private bool IsOkOrNotFound(HttpResponseMessage response)
        {
            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return true;
            if (response.StatusCode.Equals(HttpStatusCode.InternalServerError))
                return true;

            return false;
        }

    }
}

