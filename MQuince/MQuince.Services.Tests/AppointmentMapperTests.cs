using MQuince.Entities.Appointment;
using MQuince.Enums;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Implementation.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class AppointmentMapperTests
    {
        [Fact]
        public void Map_appointment_entity_to_appointment_identifier_dto()
        {
            Appointment appointment = this.GetPatient();

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

            if (!appointment.Type.Equals(appointmentDTO.EntityDTO.Type))
                return false;

            if (!appointment.StartDateTime.Equals(appointmentDTO.EntityDTO.StartDateTime))
                return false;

            if (!appointment.EndDateTime.Equals(appointmentDTO.EntityDTO.EndDateTime))
                return false;

            return true;
        }

        private Appointment GetPatient()
            => new Appointment()
            {
                Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"),
                StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
                EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                Type = TreatmentType.Examination,
                DoctorId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"),
                PatientId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa")
            };
    }
}
