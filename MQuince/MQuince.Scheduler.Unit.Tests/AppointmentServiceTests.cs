using MQuince.Core.IdentifiableDTO;
using MQuince.Infrastructure.DataProvider;
using MQuince.Scheduler.Application.Services;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Exceptions;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Contracts.Service;
using MQuince.Scheduler.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Scheduler.Unit.Tests
{
    public class AppointmentServiceTests
    {
        IAppointmentService appointmentService;
        IAppointmentRepository appointmentRepository = Substitute.For<IAppointmentRepository>();
        Infrastructure.DataProvider.IEventRepository eventRepository = Substitute.For<Infrastructure.DataProvider.IEventRepository>();

        public AppointmentServiceTests()
        {
            appointmentService = new AppointmentService(appointmentRepository, eventRepository);
        }

        [Fact]
        public void Constructor_when_given_argumet_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(appointmentRepository, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IAppointmentService appointmentService = new AppointmentService(appointmentRepository, eventRepository);

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
                new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"), new DateRange(new DateTime(2020, 12, 26, 07, 00, 00), new DateTime(2020, 12, 26, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false),
                new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(new DateTime(2020, 12, 27, 07, 00, 00), new DateTime(2020, 12, 27, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"), false)
            };

            return listOfSpecialization;
        }

        [Fact]
        public void GetById_returns_appointment()
        {
            appointmentRepository.GetById(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1")).Returns(this.GetFirstAppointment());

            IdentifiableDTO<AppointmentDTO> appointment = appointmentService.GetById(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"));

            Assert.True(this.CompareAppointmentAndIdentifierAppointment(this.GetFirstAppointment(), appointment));
        }

        [Fact]
        public void GetById_returns_null()
        {
            Appointment appointment = null;
            appointmentRepository.GetById(Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32")).Returns(appointment);

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetById(Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32")));
        }
        [Fact]
        public void GetById_returns_any_argument_null_exception()
        {
            appointmentRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void GetById_returns_any_other_exception()
        {
            appointmentRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => appointmentService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }
        private Appointment GetFirstAppointment()
           => new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"), new DateRange(new DateTime(2020, 12, 26, 07, 00, 00), new DateTime(2020, 12, 26, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false);

        [Fact]
        public void Get_appointments_for_patient_returns_appointments()
        {
            appointmentRepository.GetForPatient(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(this.GetListOfAppointments());

            List<IdentifiableDTO<AppointmentDTO>> appointments = appointmentService.GetForPatient(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).ToList();

            Assert.True(this.CompareAppointmentAndIdentifierAppointment(this.GetFirstAppointment(), appointments[0]));
            Assert.True(this.CompareAppointmentAndIdentifierAppointment(this.GetSecondAppointment(), appointments[1]));

        }

        [Fact]
        public void Get_appointments_per_patient_returns_null()
        {
            List<Appointment> appointments = null;
            appointmentRepository.GetForPatient(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(appointments);

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetForPatient(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_appointments_per_patient_returns_any_argument_null_exception()
        {
            appointmentRepository.GetForPatient(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetForPatient(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_appointments_per_patient_return_any_other_exception()
        {
            appointmentRepository.GetForPatient(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => appointmentService.GetForPatient(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_appointments_for_doctor_returns_appointments()
        {
            appointmentRepository.GetForDoctor(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(this.GetListOfAppointments());

            List<IdentifiableDTO<AppointmentDTO>> appointments = appointmentService.GetForDoctor(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).ToList();

            Assert.True(this.CompareAppointmentAndIdentifierAppointment(this.GetFirstAppointment(), appointments[0]));
            Assert.True(this.CompareAppointmentAndIdentifierAppointment(this.GetSecondAppointment(), appointments[1]));

        }

        [Fact]
        public void Get_appointments_per_doctor_returns_null()
        {
            List<Appointment> appointments = null;
            appointmentRepository.GetForDoctor(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(appointments);

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetForDoctor(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_appointments_per_doctor_returns_any_argument_null_exception()
        {
            appointmentRepository.GetForDoctor(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => appointmentService.GetForDoctor(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_appointments_per_doctor_return_any_other_exception()
        {
            appointmentRepository.GetForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => appointmentService.GetForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }
        [Fact]
        public void Get_appointment_for_doctor_for_date_return_appointments()
        {
            DateTime date = new DateTime(2020, 12, 05);
            appointmentRepository.GetAppointmentForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date).Returns(this.GetListOfAppointmentsForDoctorForDate());

            IEnumerable<IdentifiableDTO<AppointmentDTO>> appointemnts = appointmentService.GetAppointmentForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date);

            Assert.True(this.CompareAppointments(this.GetListOfAppointmentsForDoctorForDate(), appointemnts));
        }

        private IEnumerable<Appointment> GetListOfAppointmentsForDoctorForDate()
        {
            List<Appointment> listOfSpecialization = new List<Appointment>()
            {
                new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"), new DateRange(new DateTime(2020, 12, 26, 07, 00, 00), new DateTime(2020, 12, 26, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false),
                new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(new DateTime(2020, 12, 27, 07, 00, 00), new DateTime(2020, 12, 27, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false)
            };


            return listOfSpecialization;
        }

        private IEnumerable<Appointment> GetListOfFreeAppointments()
        {
            List<Appointment> listOfSpecialization = new List<Appointment>()
            {
                new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"), new DateRange(new DateTime(2020, 12, 26, 07, 00, 00), new DateTime(2020, 12, 26, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false),
                new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(new DateTime(2020, 12, 27, 07, 00, 00), new DateTime(2020, 12, 27, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false)
            };


            return listOfSpecialization;
        }

        [Fact]
        public void Cancel_appointment_when_appointment_can_be_canceled()
        {
            Appointment appointmentForCancel = this.GetAppointmentForCancelSuccesfull();
            appointmentRepository.GetById(appointmentForCancel.Id).Returns(appointmentForCancel);


            bool isCanceled = appointmentService.CancelAppointment(appointmentForCancel.Id);

            Assert.True(isCanceled);
            Assert.True(appointmentForCancel.IsCanceled);
        }

        [Fact]
        public void Cancel_appointment_when_appointment_can_not_be_canceled_because_has_expired()
        {
            Appointment appointmentForCancel = this.GetExpiredAppointment();
            appointmentRepository.GetById(appointmentForCancel.Id).Returns(appointmentForCancel);


            bool isCanceled = appointmentService.CancelAppointment(appointmentForCancel.Id);

            Assert.False(isCanceled);
            Assert.False(appointmentForCancel.IsCanceled);
        }

        [Fact]
        public void Cancel_appointment_when_appointment_can_not_be_canceled_because_appointment_is_soon()
        {
            Appointment appointmentForCancel = this.GetAppointmentWhichIsSoon();
            appointmentRepository.GetById(appointmentForCancel.Id).Returns(appointmentForCancel);

            bool isCanceled = appointmentService.CancelAppointment(appointmentForCancel.Id);

            Assert.False(isCanceled);
            Assert.False(appointmentForCancel.IsCanceled);
        }

        [Fact]
        public void Cancel_appointment_when_appointment_not_exist()
        {
            Guid appointmentId = Guid.NewGuid();
            appointmentRepository.GetById(appointmentId).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => appointmentService.CancelAppointment(appointmentId));
        }

        [Fact]
        public void Cancel_appointment_when_service_give_any_other_exception()
        {
            Guid appointmentId = Guid.NewGuid();
            appointmentRepository.GetById(appointmentId).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => appointmentService.CancelAppointment(appointmentId));
        }

        private Appointment GetAppointmentForCancelSuccesfull()
                => new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(DateTime.Now.AddHours(72), DateTime.Now.AddHours(72).AddMinutes(30)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"), false);


        private Appointment GetExpiredAppointment()
            => new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(new DateTime(2010, 12, 12, 12, 30, 00), new DateTime(2010, 12, 12, 13, 00, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"), false); 

        private Appointment GetAppointmentWhichIsSoon()
                => new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(DateTime.Now.AddHours(47), DateTime.Now.AddHours(47).AddMinutes(30)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"), false);
           

        private bool CompareAppointmentsDTO(IEnumerable<Appointment> output, IEnumerable<AppointmentDTO> appointments)
        {
            for (int i = 0; i < output.Count(); i++)
            {
                bool same = CompareAppointmentAndAppointmentDTO(output.ElementAt(i), appointments.ElementAt(i));
                if (!same)
                    return false;
            }
            return true;
        }


        private bool CompareAppointments(IEnumerable<Appointment> repo, IEnumerable<IdentifiableDTO<AppointmentDTO>> service)
        {
            for (int i = 0; i < repo.Count(); i++)
            {
                bool same = CompareAppointmentAndIdentifierAppointment(repo.ElementAt(i), service.ElementAt(i));
                if (!same)
                    return false;
            }
            return true;
        }


        private Appointment GetSecondAppointment()
            => new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"), new DateRange(new DateTime(2020, 12, 27, 07, 00, 00), new DateTime(2020, 12, 27, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"), false);

        private bool CompareAppointmentAndIdentifierAppointment(Appointment appointment, IdentifiableDTO<AppointmentDTO> identifierAppointment)
        {
            if (appointment.Id != identifierAppointment.Id)
                return false;

            if (!appointment.DoctorId.Equals(identifierAppointment.EntityDTO.DoctorId))
                return false;

            if (!appointment.PatientId.Equals(identifierAppointment.EntityDTO.PatientId))
                return false;

            if (!appointment.DateRange.StartDateTime.Equals(identifierAppointment.EntityDTO.StartDateTime))
                return false;

            if (!appointment.DateRange.EndDateTime.Equals(identifierAppointment.EntityDTO.EndDateTime))
                return false;

            if (appointment.IsCanceled != identifierAppointment.EntityDTO.IsCanceled)
                return false;

            return true;
        }

        private bool CompareAppointmentAndAppointmentDTO(Appointment appointment, AppointmentDTO appointmentDTO)
        {
            if (!appointment.DoctorId.Equals(appointmentDTO.DoctorId))
                return false;

            if (!appointment.PatientId.Equals(appointmentDTO.PatientId))
                return false;


            if (!appointment.DateRange.StartDateTime.Equals(appointmentDTO.StartDateTime))
                return false;

            if (!appointment.DateRange.EndDateTime.Equals(appointmentDTO.EndDateTime))
                return false;

            if (appointment.IsCanceled != appointmentDTO.IsCanceled)
                return false;

            return true;
        }


    }
}
