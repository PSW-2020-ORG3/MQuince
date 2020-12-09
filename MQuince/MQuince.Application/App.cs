using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Application
{
    public class App
    {
        private DbContextOptionsBuilder _optionsBuilder;
        public static IdentifiableDTO<PatientDTO> loggedPatient;

        public App(IConfiguration configuration)
        {
            _optionsBuilder = new DbContextOptionsBuilder();
            _optionsBuilder.UseMySql(configuration.GetConnectionString("MQuinceDB"));

            PatientService _patientService = (PatientService)this.GetPatientService();
            loggedPatient = _patientService.GetById(Guid.Parse("6459c216-1770-41eb-a56a-7f4524728546"));
        }

        public IUserService GetUserService()
            => new UserService(this.GetUserRepository());

        public IFeedbackService GetFeedbackService()
            => new FeedbackService(this.GetFeedbackRepository());

        private IUserRepository GetUserRepository()
            => new UserRepository(_optionsBuilder);

        private IFeedbackRepository GetFeedbackRepository()
             => new FeedbackRepository(_optionsBuilder);

        public ISpecializationService GetSpecializationService()
            => new SpecializationService(this.GetSpecializationRepository());

        public IAppointmentService GetAppointmentService()
            => new AppointmentService(this.GetAppointmentRepository(), this.GetDoctorService(), this.GetWorkTimeService());
        private IAppointmentRepository GetAppointmentRepository()
          => new AppointmentRepository(_optionsBuilder);

        private IWorkTimeService GetWorkTimeService()
            => new WorkTimeService(this.GetWorkTimeRepository());

        private IWorkTimeRepository GetWorkTimeRepository()
            => new WorkTimeRepository(_optionsBuilder);

        private ISpecializationRepository GetSpecializationRepository()
             => new SpecializationRepository(_optionsBuilder);

        public IPatientService GetPatientService()
            => new PatientService(this.GetPatientRepository());

        private IPatientRepository GetPatientRepository()
             => new PatientRepository(_optionsBuilder);

        public IDoctorService GetDoctorService()
              => new DoctorService(this.GetDoctorRepository());

        private IDoctorRepository GetDoctorRepository()
             => new DoctorRepository(_optionsBuilder);
    }
}
