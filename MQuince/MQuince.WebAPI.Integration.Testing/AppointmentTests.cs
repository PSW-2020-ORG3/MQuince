using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Services.Contracts.DTO.Appointment;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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

        [Fact]
        public async Task Create_appointments()
        {
            HttpClient client = _factory.CreateClient();
            AppointmentDTO appointmentDTO = this.GetAppointmentDTO();

            var myContent = JsonConvert.SerializeObject(appointmentDTO);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("/api/Appointment/", byteContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [MemberData(nameof(AppointmentData))]
        public async void Cancel_Appointment_Status_Code_Test(Guid appointmentId, HttpStatusCode expectedResponseStatusCode)
        {
            HttpClient client = _factory.CreateClient();

            var response = await client.PutAsync("/api/Appointment/cancelAppointment/" + appointmentId, new StringContent("1", Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBeEquivalentTo(expectedResponseStatusCode);
        }

        public static IEnumerable<object[]> AppointmentData()
        {
            var retVal = new List<object[]>();
            Guid appointmentId1 = Guid.Parse("08d8a3a6-5fcd-424e-85ce-d5276d99b442");
            Guid appointmentId2 = Guid.Parse("08d8a2ab-e138-4e36-8542-68bec07b074c");
            retVal.Add(new object[] { appointmentId1, HttpStatusCode.OK });
            retVal.Add(new object[] { appointmentId2, HttpStatusCode.BadRequest });
            return retVal;
        }

        private AppointmentDTO GetAppointmentDTO()
            =>  new AppointmentDTO()
                {
                StartDateTime = new DateTime(2010, 10, 10, 9, 0, 0),
                    EndDateTime = new DateTime(2010, 10, 10, 9, 30, 0),
                    PatientId = Guid.Parse("6459c216-1770-41eb-a56a-7f4524728546"),
                    DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"),
                    Type = Enums.TreatmentType.Examination
                };


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
