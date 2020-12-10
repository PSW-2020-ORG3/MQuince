﻿using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using MQuince.Enums;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.DTO.Users;
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
        public IDoctorService _doctorService;
        public IWorkTimeService _workTimeService;
        private IStrategy strategy;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService, IWorkTimeService workTimeService)
        {
            _appointmentRepository = appointmentRepository;
            _workTimeService = workTimeService;
            _doctorService = doctorService;
        }

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
        => _appointmentRepository.GetAll().Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));

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
            return _appointmentRepository.GetForDoctor(doctorId).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId)
        {
            return _appointmentRepository.GetForPatient(patientId).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
        }

        public void Update(AppointmentDTO entityDTO, Guid id)
        {
            _appointmentRepository.Update(CreateAppointmentFromDTO(entityDTO, id));
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time)
        {
            return _appointmentRepository.GetAppointmentForDoctorForDate(doctorId, time).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
        }


        public IEnumerable<AppointmentDTO> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime date, TreatmentType treatmentType)
        {
            List<AppointmentDTO> freeAppointments = new List<AppointmentDTO>();
            List<Appointment> appointments = _appointmentRepository.GetAppointmentForDoctorForDate(doctorId, date).ToList();

            WorkTime workTime = _workTimeService.GetWorkTimeForDoctorForDate(doctorId, date);
            if (workTime == null)
            {
                return freeAppointments;
            }
            TimeSpan appointmentDuration = GetAppointmentDuration(treatmentType);

            DateTime startDateTime = new DateTime(workTime.StartDate.Year, workTime.StartDate.Month, workTime.StartDate.Day, workTime.StartTime, 0, 0);
            DateTime endDateTime = new DateTime(workTime.EndDate.Year, workTime.EndDate.Month, workTime.EndDate.Day, workTime.EndTime, 0, 0);
            
            freeAppointments = FindFreeAppointments(appointments, startDateTime, endDateTime, appointmentDuration).ToList();
            freeAppointments = InitializeAppointments(freeAppointments, patientId, doctorId, treatmentType).ToList();

            return freeAppointments;
        }
        private TimeSpan GetAppointmentDuration(TreatmentType treatmentType)
            => new TimeSpan(0, 30, 0);

        private IEnumerable<AppointmentDTO> InitializeAppointments(IEnumerable<AppointmentDTO> appointments, Guid patientId, Guid doctorId, TreatmentType treatmentType)
        {
            foreach (AppointmentDTO appointment in appointments)
            {
                appointment.DoctorId = doctorId;
                appointment.PatientId = patientId;
                appointment.Type = treatmentType;
            }
            return appointments;
        }

        private IEnumerable<AppointmentDTO> FindFreeAppointments(List<Appointment> appointments, DateTime startDateTime, DateTime endDateTime, TimeSpan appointmentDuration)
        {
            appointments.Sort((x, y) => DateTime.Compare(x.StartDateTime, y.StartDateTime));
            List<AppointmentDTO> freeAppointments = new List<AppointmentDTO>();

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
        public IEnumerable<AppointmentDTO> FillFreeInterval(DateTime startTime, DateTime endTime, TimeSpan appointmentDuration)
        {
            List<AppointmentDTO> freeAppointments = new List<AppointmentDTO>();
            while (endTime - startTime >= appointmentDuration)
            {
                AppointmentDTO freeAppointment = new AppointmentDTO() { StartDateTime = startTime, EndDateTime = startTime.Add(appointmentDuration) };
                startTime = freeAppointment.EndDateTime;
                freeAppointments.Add(freeAppointment);
            }
            return freeAppointments;
        }

        public AppointmentDTO GetExaminationInRange(DateTime dateFrom, DateTime dateTo, Guid patientId, Guid doctorId)
        {
            List<AppointmentDTO> freeAppointments;
            TreatmentType treatmentType = TreatmentType.Examination;
            for (DateTime date = dateFrom; date <= dateTo; date = date.AddDays(1))
            {
                freeAppointments = GetFreeAppointments(patientId, doctorId, date, treatmentType).ToList();
                if (freeAppointments.Count > 0)
                {
                    return freeAppointments[0];
                }
            }
            return null;
        }

        public AppointmentDTO RecommendAppointment(RecommendAppointmentParameters parameters)
        {
            strategy = ChooseSrategy(parameters);
            AppointmentDTO appointment = GetExaminationInRange(parameters.DateFrom, parameters.DateTo, parameters.PatientId, parameters.DoctorId);
            if (appointment != null)
            {
                return appointment;
            }
            else
            {
                return strategy.recommend(parameters.PatientId, parameters.DoctorId);
            }
        }

        IStrategy ChooseSrategy(RecommendAppointmentParameters parameters)
             => (parameters.Priority == AppointmentPriority.DatePriority) ? (IStrategy)new DatePriorityStrategy(this, parameters) : new DoctorPriorityStrategy(this, parameters);
    }
}