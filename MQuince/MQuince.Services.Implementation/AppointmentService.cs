using MQuince.Entities.Appointment;
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
            return _appointmentRepository.GetForDoctor(patientId).Select(c => CreateDTOFromAppointment(c));
        }

        public void Update(AppointmentDTO entityDTO, Guid id)
        {
            _appointmentRepository.Update(CreateAppointmentFromDTO(entityDTO, id));
        }
    }
}
