using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Application.Services.Util;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Exceptions;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Contracts.Service;
using MQuince.Scheduler.Domain;
using MQuince.Scheduler.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;
        private IEventRepository _eventRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IEventRepository eventRepository)
        {
            _appointmentRepository = appointmentRepository == null ? throw new ArgumentNullException(nameof(appointmentRepository) + "is set to null") : appointmentRepository;
            _eventRepository = eventRepository == null ? throw new ArgumentNullException(nameof(eventRepository) + "is set to null") : eventRepository;
        }

        public Guid Create(AppointmentDTO entityDTO)
        {
            Appointment appointment = CreateAppointmentFromDTO(entityDTO);
            ScheduleEvent scheduleEvent = new ScheduleEvent(ScheduleEventType.CREATED, appointment.Id, appointment.PatientId);

            _appointmentRepository.Create(appointment);
            _eventRepository.Create(scheduleEvent);

            return appointment.Id;
        }
        private Appointment CreateAppointmentFromDTO(AppointmentDTO appointment, Guid? id = null)
            => id == null ? new Appointment(new DateRange(appointment.StartDateTime, appointment.EndDateTime), appointment.DoctorId, appointment.PatientId, appointment.IsCanceled)
                          : new Appointment(new DateRange(appointment.StartDateTime, appointment.EndDateTime), appointment.DoctorId, appointment.PatientId, appointment.IsCanceled);

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAll()
        {
            try
            {
                return _appointmentRepository.GetAll().Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        public IdentifiableDTO<AppointmentDTO> GetById(Guid id)
        {
            try
            {
                return AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(_appointmentRepository.GetById(id));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }
        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForDoctor(Guid doctorId)
        {
            try
            {
                return _appointmentRepository.GetForDoctor(doctorId).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId)
        {
            try
            {
                return _appointmentRepository.GetForPatient(patientId).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        public void Update(AppointmentDTO entityDTO, Guid id)
        {
            _appointmentRepository.Update(CreateAppointmentFromDTO(entityDTO, id));
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time)
        {
            try
            {
                return _appointmentRepository.GetAppointmentForDoctorForDate(doctorId, time).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        public bool CancelAppointment(Guid appointmentId)
        {
            try
            {
                Appointment appointment = _appointmentRepository.GetById(appointmentId);
                ScheduleEvent scheduleEvent = new ScheduleEvent(ScheduleEventType.CANCELED, appointment.Id, appointment.PatientId);

                if (appointment.IsCancelable())
                {
                    appointment.Cancel();
                    _appointmentRepository.Update(appointment);
                    _eventRepository.Create(scheduleEvent);
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime date)
        {
            DateRange workHours = GetWorkHours(doctorId, date).Result;
            IEnumerable<Appointment> scheduledAppointments = _appointmentRepository.GetAppointmentForDoctorForDate(doctorId, date);
            Domain.Scheduler scheduler = new Domain.Scheduler(scheduledAppointments, workHours);
            return scheduler.GetFreeAppointments().Select(c => InitializeAppointments(c, patientId, doctorId));
        }

        private IdentifiableDTO<AppointmentDTO> InitializeAppointments(Appointment appointment, Guid patientId, Guid doctorId)
        {
            IdentifiableDTO<AppointmentDTO> appointmentDTO = AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(appointment);
            appointmentDTO.EntityDTO.PatientId = patientId;
            appointmentDTO.EntityDTO.DoctorId = doctorId;
            return appointmentDTO;
        }

        private async Task<DateRange> GetWorkHours(Guid doctorId, DateTime date)
        {
            var stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";
            stage = ExtractArgument(stage);
            string URL = $"http://localhost:5003/api/worktime/GetWorkHours?doctorId={doctorId}&date={date}";
            if (stage == "test")
                URL = $"https://mquince-staff.herokuapp.com/api/worktime/GetWorkHours?doctorId={doctorId}&date={date}";
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(URL);
            HttpContent content = res.Content;
            string data = await content.ReadAsStringAsync();
            DateRange workHours = JsonConvert.DeserializeObject<DateRange>(data);
            return workHours;
        }

        private string ExtractArgument(string argument)
        {
            string retVal = argument.Replace("=", "");
            return retVal.Trim();
        }
    }
}
