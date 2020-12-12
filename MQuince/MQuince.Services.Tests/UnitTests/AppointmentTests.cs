using Moq;
using MQuince.Entities.Appointment;
using MQuince.Enums;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace MQuince.Services.Tests.UnitTests
{
    public class AppointmentTests
    {
        [Fact]
        public void Cancel_appointment()
        {
            AppointmentService _appointmentService = new AppointmentService(CreateStubRepository());

            Guid IdAppointment = Guid.Parse("08d89d75-3533-47ac-80a1-6cd77742dd25");

            _appointmentService.CancelAppointment(IdAppointment);
            IdentifiableDTO<AppointmentDTO> canceledAppointment = _appointmentService.GetById(IdAppointment);

            Assert.True(canceledAppointment.EntityDTO.IsCanceled);
        }

        [Fact]
        public void Cancel_appointment_when_is_invalid_data_returns_null()
        {
            AppointmentService _appointmentService = new AppointmentService(CreateStubRepository());

            Guid IdAppointment = Guid.Parse("08d89d75-46c4-4e41-8da0-54cc9586c109");

            _appointmentService.CancelAppointment(IdAppointment);
            IdentifiableDTO<AppointmentDTO> canceledAppointment = _appointmentService.GetById(IdAppointment);

            Assert.False(canceledAppointment.EntityDTO.IsCanceled);
        }


        private static IAppointmentRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<Appointment>();
            Guid IdAppointment1 = Guid.Parse("08d89d75-3533-47ac-80a1-6cd77742dd25");
            Guid IdAppointment2 = Guid.Parse("08d89d75-46c4-4e41-8da0-54cc9586c109");
            Guid IdAppointment3 = Guid.Parse("08d89d76-5a15-4560-8d39-dd56c5ad776e");
            Guid DoctorPersistanceId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32");
            Guid IdPatient = Guid.Parse("6459c216-1770-41eb-a56a-7f4524728546");
            TreatmentType treatmentType = TreatmentType.Examination;
            

            appointments.Add(new Appointment(IdAppointment1, new DateTime(2020, 12, 21, 12, 30, 0), new DateTime(2020, 12, 21, 13, 00, 0), treatmentType, DoctorPersistanceId, IdPatient, false));
            appointments.Add(new Appointment(IdAppointment2, new DateTime(2020, 12, 11, 10, 30, 0), new DateTime(2020, 12, 14, 11, 00, 0), treatmentType, DoctorPersistanceId, IdPatient, false));
            appointments.Add(new Appointment(IdAppointment3, new DateTime(2020, 12, 13, 08, 00, 0), new DateTime(2020, 12, 13, 08, 30, 0), treatmentType, DoctorPersistanceId, IdPatient, true));

            stubRepository.Setup(appointmentsRepository => appointmentsRepository.GetAll()).Returns(appointments);
            stubRepository.Setup(appointmentsRepository => appointmentsRepository.GetById(It.IsAny<Guid>())).Returns((Guid id) => appointments.Find(m => m.Id == id));
            stubRepository.Setup(appointment => appointment.Update(It.IsAny<Appointment>()))
                .Callback((Appointment appointment) =>
                {
                    Appointment existingAppointment = appointments.Find(a => a.Id == appointment.Id);
                    existingAppointment.IsCanceled = true;
                });
            return stubRepository.Object;
        }

    }
}
