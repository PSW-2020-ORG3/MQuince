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

        public App(string connectionString)
        {
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";
            //stage = "test";
            _optionsBuilder = new DbContextOptionsBuilder();
            if (stage == "dev")
            {
                _optionsBuilder.UseMySql(connectionString);
            }
            else
            {
                _optionsBuilder.UseNpgsql(connectionString);
            }


            //PatientService _patientService = (PatientService)this.GetPatientService();
            //loggedPatient = _patientService.GetById(Guid.Parse("6459c216-1770-41eb-a56a-7f4524728546"));
        }

        public IUserService GetUserService()
            => new UserService(this.GetUserRepository());

        public IFeedbackService GetFeedbackService()
            => new FeedbackService(this.GetFeedbackRepository());


        private IFeedbackRepository GetFeedbackRepository()
             => new FeedbackRepository(_optionsBuilder);

        public ISpecializationService GetSpecializationService()
            => new SpecializationService(this.GetSpecializationRepository());

        public IAppointmentService GetAppointmentService()
            => new AppointmentService(this.GetAppointmentRepository(), this.GetWorkTimeService());
        private IAppointmentRepository GetAppointmentRepository()
          => new AppointmentRepository(_optionsBuilder);

        private IWorkTimeService GetWorkTimeService()
            => new WorkTimeService(this.GetWorkTimeRepository());

        private IWorkTimeRepository GetWorkTimeRepository()
            => new WorkTimeRepository(_optionsBuilder);

        private ISpecializationRepository GetSpecializationRepository()
             => new SpecializationRepository(_optionsBuilder);

        public IPatientService GetPatientService()
            => new PatientService(this.GetUserRepository());

        public IDoctorService GetDoctorService()
              => new DoctorService(this.GetUserRepository());

        private IUserRepository GetUserRepository()
             => new UserRepository(_optionsBuilder);

    }
}
