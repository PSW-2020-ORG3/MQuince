using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Application.Contracts;
using MQuince.Scheduler.Application.Contracts.Exceptions;
using MQuince.Scheduler.Application.DTO;
using MQuince.Scheduler.Application.Services.Util;
using MQuince.Scheduler.Domain;
using MQuince.Scheduler.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Services
{
	public class AppointmentService : IAppointmentService
	{
        private IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository == null ? throw new ArgumentNullException(nameof(appointmentRepository) + "is set to null") : appointmentRepository;
        }

        public Guid Create(AppointmentDTO entityDTO)
        {
            Appointment appointment = CreateAppointmentFromDTO(entityDTO);

            _appointmentRepository.Create(appointment);

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
            catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception e)
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
            try
            {
                return _appointmentRepository.GetForDoctor(doctorId).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
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

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId)
        {
            try
            {
                return _appointmentRepository.GetForPatient(patientId).Select(c => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(c));
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
            catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

        public bool CancelAppointment(Guid appointmentId)
        {
            try
            {
                Appointment appointment = _appointmentRepository.GetById(appointmentId);
                if (appointment.IsCancelable())
                {
                    appointment.Cancel();
                    _appointmentRepository.Update(appointment);
                    return true;
                }
                return false;
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

		public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime date)
		{
            IEnumerable<Appointment> scheduledAppointments = _appointmentRepository.GetAppointmentForDoctorForDate(doctorId, date);
            DateTime startWorkHour = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0);
            DateTime endWorkHour = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
            DateRange workHours = new DateRange(startWorkHour, endWorkHour);
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
	}
}
