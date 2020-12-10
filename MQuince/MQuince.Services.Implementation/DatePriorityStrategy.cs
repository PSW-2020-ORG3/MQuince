using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class DatePriorityStrategy : IStrategy
    {
        public RecommendAppointmentParameters _parameters;
        public IAppointmentService _appointmentService;
        public IDoctorService _doctorService;
        public IDoctorRepository _doctorRepository;
        public ISpecializationService specializationService;
        private AppointmentService appointmentService;
        private RecommendAppointmentParameters parameters;

        public DatePriorityStrategy(IAppointmentService appointmentService, RecommendAppointmentParameters parameters)
        {
            _appointmentService = appointmentService;
            _parameters = parameters;
        }

        public DatePriorityStrategy(IAppointmentService appointmentService, RecommendAppointmentParameters parameters, IDoctorService doctorService, IDoctorRepository doctorRepository)
        {
            _appointmentService = appointmentService;
            _parameters = parameters;
            _doctorService = doctorService;
            _doctorRepository = doctorRepository;
        }
        
        public AppointmentDTO recommend(Guid patientId, Guid doctorId)
        {
            AppointmentDTO freeAppointment = null;
            Specialization specialization = new Specialization() { Name = "Lekar opste prakse" };
            List<Doctor> doctors = (List<Doctor>)_doctorRepository.GetDoctorsPerSpecialization(doctorId);
            foreach (Doctor doctor in doctors)
            {
                freeAppointment = _appointmentService.GetExaminationInRange(_parameters.DateFrom, _parameters.DateTo, patientId, doctor.Id);
                if (freeAppointment != null)
                {
                    return freeAppointment;
                }
            }
            return freeAppointment;
        }
    }
}
