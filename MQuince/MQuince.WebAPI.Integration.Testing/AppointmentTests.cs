using Microsoft.AspNetCore.Mvc.Testing;
using MQuince.Services.Contracts.DTO.Appointment;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        [Fact]
        public async Task Cancel_appointment()
        {
            HttpClient client = _factory.CreateClient();
            Guid appointmentId = Guid.NewGuid();
            string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(appointmentId);
            var httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("/api/Appointment/CancelAppointment/"+ appointmentId, httpContent);

            Assert.True(IsOkOrNotFoundOrBadRequest(response));
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
