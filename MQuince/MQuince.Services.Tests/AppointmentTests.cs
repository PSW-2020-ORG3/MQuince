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
using Xunit;


namespace MQuince.Services.Tests.UnitTests
{
    public class AppointmentTests
    {

        IAppointmentService appointmentService;
        IAppointmentRepository appointmentRepository = Substitute.For<IAppointmentRepository>();
        IWorkTimeService workTimeService = Substitute.For<IWorkTimeService>();

        public AppointmentTests()
        {
            appointmentService = new AppointmentService(appointmentRepository, workTimeService);
        }

        [Fact]
        public void Constructor_when_given_argumet_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(appointmentRepository, null));
            Assert.Throws<ArgumentNullException>(() => new AppointmentService(null, workTimeService));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IAppointmentService appointmentService = new AppointmentService(appointmentRepository, workTimeService);


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
                    PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"),
                    IsCanceled= false
                },new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                    StartDateTime = new DateTime(2020, 12, 27, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 27, 07, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                    PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"),
                    IsCanceled= false
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
               PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"),
               IsCanceled = false
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
            DateTime date = new DateTime(2020, 12, 05);
            appointmentRepository.GetAppointmentForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date).Returns(this.GetListOfAppointmentsForDoctorForDate());

            IEnumerable<IdentifiableDTO<AppointmentDTO>> appointemnts = appointmentService.GetAppointmentForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date);

            Assert.True(this.CompareAppointments(this.GetListOfAppointmentsForDoctorForDate(), appointemnts));
        }

        private IEnumerable<Appointment> GetListOfAppointmentsForDoctorForDate()
        {
            List<Appointment> listOfSpecialization = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"),
                    StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"),
                    PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"),
                    IsCanceled=false
                },new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                    StartDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 08, 00, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"),
                    PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"),
                    IsCanceled=false
                }
            };


            return listOfSpecialization;
        }

        private IEnumerable<Appointment> GetListOfFreeAppointments()
        {
            List<Appointment> listOfSpecialization = new List<Appointment>()
            {
                new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea3"),
                    StartDateTime = new DateTime(2020, 12, 26, 08, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 08, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"),
                    PatientId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051ad11"),
                    IsCanceled=false
                },new Appointment()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea4"),
                    StartDateTime = new DateTime(2020, 12, 26, 08, 30, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 09, 00, 00),
                    Type = TreatmentType.Examination,
                    DoctorId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"),
                    PatientId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051ad11"),
                    IsCanceled=false
                }
            };


            return listOfSpecialization;
        }

        [Fact]
        public void Get_free_appointments_return_appointments()
        {
            Guid patientId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051ad11");
            Guid doctorId = Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba");
            DateTime date = new DateTime(2020, 12, 26);
            TreatmentType treatmentType = TreatmentType.Examination;
            appointmentRepository.GetAppointmentForDoctorForDate(doctorId, date).Returns(this.GetListOfAppointmentsForDoctorForDate());
            workTimeService.GetWorkTimeForDoctorForDate(doctorId, date).Returns(GetFirstWorkTime());

            IEnumerable<AppointmentDTO> appointments = appointmentService.GetFreeAppointments(patientId, doctorId, date, treatmentType);

            IEnumerable<Appointment> output = GetListOfFreeAppointments();
            Assert.True(CompareAppointmentsDTO(output, appointments));
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
            => new Appointment()
            {
                Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                StartDateTime = DateTime.Now.AddHours(72),
                EndDateTime = DateTime.Now.AddHours(72).AddMinutes(30),
                Type = TreatmentType.Examination,
                DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"),
                IsCanceled = false
            };

        private Appointment GetExpiredAppointment()
            => new Appointment()
            {
                Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                StartDateTime = new DateTime(2010, 12, 12, 12, 30, 00),
                EndDateTime = new DateTime(2010, 12, 12, 12, 30, 00),
                Type = TreatmentType.Examination,
                DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"),
                IsCanceled = false
            };

        private Appointment GetAppointmentWhichIsSoon()
            => new Appointment()
            {
                Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                StartDateTime = DateTime.Now.AddHours(47),
                EndDateTime = DateTime.Now.AddHours(47).AddMinutes(30),
                Type = TreatmentType.Examination,
                DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"),
                IsCanceled = false
            };

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
            => new Appointment()
            {
                Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea2"),
                StartDateTime = new DateTime(2020, 12, 27, 07, 00, 00),
                EndDateTime = new DateTime(2020, 12, 27, 07, 30, 00),
                Type = TreatmentType.Examination,
                DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b72"),
                PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595dca"),
                IsCanceled = false
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

            if (!appointment.Type.Equals(appointmentDTO.Type))
                return false;

            if (!appointment.StartDateTime.Equals(appointmentDTO.StartDateTime))
                return false;

            if (!appointment.EndDateTime.Equals(appointmentDTO.EndDateTime))
                return false;

            if (appointment.IsCanceled != appointmentDTO.IsCanceled)
                return false;

            return true;
        }

        private WorkTime GetFirstWorkTime()
                => new WorkTime(Guid.Parse("6a3d67e0-6af6-4947-919f-7a1a80023db3"), new DateTime(2020, 12, 26), new DateTime(2020, 12, 26), 7, 9, Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"));

        private WorkTime GetSecondWorkTime()
           => new WorkTime(Guid.Parse("c1d9ae05-81aa-4203-a830-692383bfca09"), new DateTime(2020, 12, 27), new DateTime(2020, 12, 27), 9, 12, Guid.Parse("7bb28807-f41e-4bf4-b699-6a4780511111"));


        private List<WorkTime> GetListOfWorkTimes()
        {
            List<WorkTime> listOfWorkTime = new List<WorkTime>();
            listOfWorkTime.Add(this.GetFirstWorkTime());
            listOfWorkTime.Add(this.GetSecondWorkTime());
            return listOfWorkTime;
        }

    }
}
