using Moq;
using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Enums;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;


namespace MQuince.Services.Tests.UnitTests
{
    public class AppointmentTests
    {

        IAppointmentService appointmentService;
        IAppointmentRepository appointmentRepository = Substitute.For<IAppointmentRepository>();

        public AppointmentTests()
        {
            appointmentService = new AppointmentService(appointmentRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IAppointmentService appointmentService = new AppointmentService(appointmentRepository);


            Assert.IsType<AppointmentService>(appointmentService);
        }

        [Fact]
        public void GetAll_returns_data()
        {
            appointmentRepository.GetAll().Returns(this.GetListOfAppointments());

            List<IdentifiableDTO<AppointmentDTO>> returnedList = appointmentService.GetAll().ToList();

            Assert.Equal(returnedList[0].Id, Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"));
            Assert.Equal(new DateTime(2020, 12, 26, 07, 00, 00), returnedList[0].EntityDTO.StartDateTime);
            Assert.Equal(new DateTime(2020, 12, 26, 07, 30, 00), returnedList[0].EntityDTO.EndDateTime);
            Assert.Equal(Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), returnedList[0].EntityDTO.PatientId);
            Assert.Equal(Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), returnedList[0].EntityDTO.DoctorId);

            Assert.Equal(returnedList[1].Id, Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"));
            Assert.Equal(new DateTime(2020, 12, 27, 07, 00, 00), returnedList[1].EntityDTO.StartDateTime);
            Assert.Equal(new DateTime(2020, 12, 27, 07, 30, 00), returnedList[1].EntityDTO.EndDateTime);
            Assert.Equal(Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"), returnedList[1].EntityDTO.PatientId);
            Assert.Equal(Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"), returnedList[1].EntityDTO.DoctorId);
        }

        [Fact]
        public void GetAll_returns_null()
        {
            List<Appointment> listOfAppointemnts = null;
            appointmentRepository.GetAll().Returns(listOfAppointemnts);

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetAll());
        }

        [Fact]
        public void GetAll_returns_any_argument_null_exception()
        {
            appointmentRepository.GetAll().Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetAll());
        }

        [Fact]
        public void GetAll_returns_any_other_exception()
        {
            appointmentRepository.GetAll().Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => appointmentService.GetAll());
        }

        private List<Appointment> GetListOfAppointments()
        {
            List<Appointment> listOfSpecialization = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"),
                    StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"),
                    PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa")
                },new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                    StartDateTime = new DateTime(2020, 12, 27, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 27, 07, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                    PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca")
                }
            };


            return listOfSpecialization;
        }

        [Fact]
        public void Cancel_appointment()
        {
            AppointmentService _appointmentService = new AppointmentService(CreateWorkTimeStubRepository());

            Guid IdAppointment = Guid.Parse("08d89d75-3533-47ac-80a1-6cd77742dd25");

            _appointmentService.CancelAppointment(IdAppointment, new DateTime(2020, 12, 15));
            Appointment canceledAppointment = _appointmentService.GetAppointment(IdAppointment);

            Assert.True(canceledAppointment.IsCanceled);
        }

        [Fact]
        public void Cancel_appointment_invalid_data()
        {
            AppointmentService _appointmentService = new AppointmentService(CreateWorkTimeStubRepository());

            Guid IdAppointment = Guid.Parse("08d89d75-3533-47ac-80a1-6cd77742dd25");

            _appointmentService.CancelAppointment(IdAppointment, new DateTime(2020, 12, 20));
            Appointment canceledAppointment = _appointmentService.GetAppointment(IdAppointment);

            Assert.False(canceledAppointment.IsCanceled);
        }


        private static IAppointmentRepository CreateAppointmentRepository()
        {

            var stubRepository = new Mock<IAppointmentRepository>();

            return stubRepository.Object;
        }
        private static IAppointmentRepository CreateWorkTimeStubRepository()
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
            appointments.Add(new Appointment(IdAppointment2, new DateTime(2020, 12, 14, 10, 30, 0), new DateTime(2020, 12, 14, 11, 00, 0), treatmentType, DoctorPersistanceId, IdPatient, false));
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
