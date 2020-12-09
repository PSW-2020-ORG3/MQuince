using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Enums;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        public IAppointmentRepository _appointmentRepository;
        public IDoctorRepository _doctroRepository;

        public Guid Create(AppointmentDTO entityDTO)
        {
            Appointment appointment = CreateAppointmentFromDTO(entityDTO);

            _appointmentRepository.Create(appointment);

            return appointment.Id;
        }
        private Appointment CreateAppointmentFromDTO(AppointmentDTO appointment, Guid? id = null)
            => id == null ? new Appointment(appointment.StartDateTime, appointment.EndDateTime, appointment.Type, appointment.DoctorId, appointment.PatientId)
                          : new Appointment(appointment.StartDateTime, appointment.EndDateTime, appointment.Type, appointment.DoctorId, appointment.PatientId);

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAll()
        => _appointmentRepository.GetAll().Select(c => CreateDTOFromAppointment(c));

        /// <summary>
        /// Mathod for sreate DTO from feedbacks
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        private IdentifiableDTO<AppointmentDTO> CreateDTOFromAppointment(Appointment appointment)
        {
            if (appointment == null) return null;

            return new IdentifiableDTO<AppointmentDTO>()
            {
                Id = appointment.Id,
                EntityDTO = new AppointmentDTO()
                {
                    StartDateTime = appointment.StartDateTime,
                    EndDateTime = appointment.EndDateTime,
                    Type = appointment.Type,
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId
                }

            };
        }

        public IdentifiableDTO<AppointmentDTO> GetById(Guid id)
        {
            try
            {
                return AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(_appointmentRepository.GetById(id));
            }
            catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }
        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForDoctor(Guid doctorId)
        {
            return _appointmentRepository.GetForDoctor(doctorId).Select(c => CreateDTOFromAppointment(c));
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId)
        {
            return _appointmentRepository.GetForPatient(patientId).Select(c => CreateDTOFromAppointment(c));
        }

        public void Update(AppointmentDTO entityDTO, Guid id)
        {
            _appointmentRepository.Update(CreateAppointmentFromDTO(entityDTO, id));
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time)
        {
            return _appointmentRepository.GetAppointmentForDoctorForDate(doctorId, time).Select(c => CreateDTOFromAppointment(c));
        }


        //User patient, User doctor, DateTime date, TreatmentType treatmentType
        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime startDateTime, DateTime endDateTime, TreatmentType treatmentType)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            Doctor doctorObject = (Doctor)_doctroRepository.GetById(doctorId);
            
            List<Appointment> appointments = GetAppointmentForDoctorForDate(doctorId, startDateTime).ToList();
            EmployeeWorkDay employeeWorkDay = WorkTimeService.GetEmployeeWorkDay(doctor, date);
            if (employeeWorkDay == null)
            {
                return freeAppointments;
            }
            TimeSpan appointmentDuration = GetAppointmentDuration(treatmentType);
            freeAppointments = FindFreeAppointments(appointments, employeeWorkDay, appointmentDuration).ToList();
            freeAppointments = InitializeAppointments(freeAppointments, patientId, doctorId, treatmentType).ToList();
            return freeAppointments;
        }
        private TimeSpan GetAppointmentDuration(TreatmentType treatmentType)
            => (treatmentType == TreatmentType.Surgery) ? new TimeSpan(0, App.DefaultAppointmentSurgeryDuration, 0) : new TimeSpan(0, App.DefaultAppointmentExaminationDuration, 0);

        private IEnumerable<Appointment> InitializeAppointments(IEnumerable<Appointment> appointments, Guid patientId, Guid doctorId, TreatmentType treatmentType)
        {
            foreach (Appointment appointment in appointments)
            {
                appointment.DoctorId = doctorId;
                appointment.PatientId = patientId;
                appointment.Type = treatmentType;
            }
            return appointments;
        }

        private IEnumerable<Appointment> FindFreeAppointments(List<Appointment> appointments, DateTime startDateTime, DateTime endDateTime, TimeSpan appointmentDuration)
        {
            appointments.Sort((x, y) => DateTime.Compare(x.StartDateTime, y.StartDateTime));
            List<Appointment> freeAppointments = new List<Appointment>();

            DateTime startTime = startDateTime;
            DateTime endTime;
            if (appointments.Any())
            {
                foreach (Appointment appointment in appointments)
                {
                    endTime = appointment.StartDateTime;
                    freeAppointments.AddRange(FillFreeInterval(startTime, endTime, appointmentDuration));
                    startTime = appointment.EndDateTime;
                }
            }
            endTime = endDateTime;
            freeAppointments.AddRange(FillFreeInterval(startTime, endTime, appointmentDuration));
            return freeAppointments;
        }
        public IEnumerable<Appointment> FillFreeInterval(DateTime startTime, DateTime endTime, TimeSpan appointmentDuration)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            while (endTime - startTime >= appointmentDuration)
            {
                Appointment freeAppointment = new Appointment() { StartDateTime = startTime, EndDateTime = startTime.Add(appointmentDuration) };
                startTime = freeAppointment.EndDateTime;
                freeAppointments.Add(freeAppointment);
            }
            return freeAppointments;
        }


    }
}
