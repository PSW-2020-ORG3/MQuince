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
        IDoctorService doctorService = Substitute.For<IDoctorService>();
        IWorkTimeService workTimeService = Substitute.For<IWorkTimeService>();
        public AppointmentTests()
        {
            appointmentService = new AppointmentService(appointmentRepository, doctorService, workTimeService);
        }

        [Fact]
        public void Constructor_when_given_argumet_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(appointmentRepository, null, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(appointmentRepository, doctorService, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(appointmentRepository, null, workTimeService));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, doctorService, workTimeService));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, null, workTimeService));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, doctorService, null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IAppointmentService appointmentService = new AppointmentService(appointmentRepository, doctorService, workTimeService);


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
           => new Appointment()
           {
               Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"),
               StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
               EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
               Type = TreatmentType.Examination,
               DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"),
               PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa")
           };

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
            appointmentRepository.GetForDoctor(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba")).Returns(this.GetListOfAppointments());
            DateTime date = new DateTime(2020, 12, 05);

            List<IdentifiableDTO<AppointmentDTO>> appointemnts = appointmentService.GetAppointmentForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date).ToList();

            Assert.True(this.CompareAppointmentsForDoctorForDate(this.GetListOfAppointments(), appointemnts, date));
        }
        
        private Appointment GetSecondAppointment()
            => new Appointment()
            {
                Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                StartDateTime = new DateTime(2020, 12, 27, 07, 00, 00),
                EndDateTime = new DateTime(2020, 12, 27, 07, 30, 00),
                Type = TreatmentType.Examination,
                DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca")
            };
        private bool CompareAppointmentAndIdentifierAppointment(Appointment appointment, IdentifiableDTO<AppointmentDTO> identifierAppointment)
        {
            if (appointment.Id != identifierAppointment.Id)
                return false;

            if (!appointment.DoctorId.Equals(identifierAppointment.EntityDTO.DoctorId))
                return false;

            if (!appointment.PatientId.Equals(identifierAppointment.EntityDTO.PatientId))
                return false;

            if (!appointment.Type.Equals(identifierAppointment.EntityDTO.Type))
                return false;

            if (!appointment.StartDateTime.Equals(identifierAppointment.EntityDTO.StartDateTime))
                return false;

            if (!appointment.EndDateTime.Equals(identifierAppointment.EntityDTO.EndDateTime))
                return false;

            return true;
        }
        private bool CompareAppointmentsForDoctorForDate(List<Appointment> appointemntsFirst, List<IdentifiableDTO<AppointmentDTO>> appointemntsSecond, DateTime date)
        {
            bool temporary = false;
            foreach (Appointment a in appointemntsFirst)
            {
                if (a.StartDateTime.Date == date)
                {
                    temporary = false;
                    foreach (IdentifiableDTO<AppointmentDTO> a2 in appointemntsSecond)
                    {
                        if (a2.EntityDTO.StartDateTime.Date == date)
                        {
                            if (a.Id == a2.Id)
                                temporary = true;
                        }
                    }
                    if (temporary == false)
                        return false;
                }
            }

            return true;
        }

    }
}
