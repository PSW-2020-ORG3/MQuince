using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Application.Services.Util;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Domain;
using System;
using Xunit;

namespace MQuince.Scheduler.Unit.Tests
{
    public class AppointmentMapperTests
    {
        [Fact]
        public void Map_appointment_entity_to_appointment_identifier_dto()
        {
            Appointment appointment = this.GetAppointment();

            IdentifiableDTO<AppointmentDTO> appointmentDTO = AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(appointment);

            Assert.True(IsEqualAppointmentPersistanceAndAppointmentEntity(appointmentDTO, appointment));
        }

        [Fact]
        public void Map_appointment_persistence_to_appointment_entity_when_appointment_persistance_is_null()
        {
            Appointment appointment = null;

            Assert.Throws<ArgumentNullException>(()
                 => AppointmentMapper.MapAppointmentEntityToAppointmentIdentifierDTO(appointment));
        }

        public bool IsEqualAppointmentPersistanceAndAppointmentEntity(IdentifiableDTO<AppointmentDTO> appointmentDTO, Appointment appointment)
        {

            if (appointment.Id != appointmentDTO.Id)
                return false;

            if (!appointment.DoctorId.Equals(appointmentDTO.EntityDTO.DoctorId))
                return false;

            if (!appointment.PatientId.Equals(appointmentDTO.EntityDTO.PatientId))
                return false;


            if (!appointment.DateRange.StartDateTime.Equals(appointmentDTO.EntityDTO.StartDateTime))
                return false;

            if (!appointment.DateRange.EndDateTime.Equals(appointmentDTO.EntityDTO.EndDateTime))
                return false;

            if (appointment.IsCanceled != appointmentDTO.EntityDTO.IsCanceled)
                return false;

            return true;
        }

        private Appointment GetAppointment()
            => new Appointment(Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"), new DateRange(new DateTime(2020, 12, 26, 07, 00, 00), new DateTime(2020, 12, 26, 07, 30, 00)), Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"), Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"), false);

    }
}
