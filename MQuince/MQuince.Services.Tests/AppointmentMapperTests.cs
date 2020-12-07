using MQuince.Entities.Appointments;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Implementation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class AppointmentMapperTests
    {
        [Fact]
        public void Map_appointment_entity_to_identifier_appointment_dto()
        {
            Appointment appointment = this.GetAppointmentFirst();

            IdentifiableDTO<AppointmentDTO> identifierAppointmentDTO = AppointmentMapper.MapAppointmentEntityToIdentifierAppointmentDTO(appointment);

            Assert.True(IsEqualAppointmentEntitiesAndIdentifierAppointmentDTO(appointment, identifierAppointmentDTO));
        }

        [Fact]
        public void Map_appointment_entity_to_identifier_appointment_dto_when_when_entity_is_null()
        {
            Appointment appointment = null;

            Assert.Throws<ArgumentNullException>(()
                 => AppointmentMapper.MapAppointmentEntityToIdentifierAppointmentDTO(appointment));
        }

        [Fact]
        public void Map_appointment_entites_collection_to_identifier_appointmentDTO_collection()
        {
            List<Appointment> listOfappointments = this.GetListOfAppointments();

            List<IdentifiableDTO<AppointmentDTO>> listOfIdentifierAppointmentDTO = AppointmentMapper.MapAppointmentEntityCollectionToIdentifierAppointmentDTOCollection(listOfappointments).ToList();

            Assert.True(this.IsEqualAppointmentEntitiesAndIdentifierAppointmentDTO(listOfappointments[0], listOfIdentifierAppointmentDTO[0]));
            Assert.True(this.IsEqualAppointmentEntitiesAndIdentifierAppointmentDTO(listOfappointments[1], listOfIdentifierAppointmentDTO[1]));
        }

        [Fact]
        public void Map_appointment_entities_collection_to_identifier_appointmentDTO_collection_when_entities_collection_is_null()
        {
            List<Appointment> listOfAppointments = null;

            Assert.Throws<ArgumentNullException>(()
                    => AppointmentMapper.MapAppointmentEntityCollectionToIdentifierAppointmentDTOCollection(listOfAppointments));
        }

        private List<Appointment> GetListOfAppointments()
        {
            List<Appointment> listOfAppointments = new List<Appointment>();

            listOfAppointments.Add(this.GetAppointmentFirst());
            listOfAppointments.Add(this.GetAppointmentSecond());

            return listOfAppointments;
        }


        private Appointment GetAppointmentFirst()
                => new Appointment()
                {
                    Id = Guid.Parse("1d5a046-bc14-4cce-9ab0-222565f50526"),
                    StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                    isCanceled = false,
                    DoctorId = Guid.Parse("54475a55-054f-4081-89b3-757cafbd5ea1")
                };

        private Appointment GetAppointmentSecond()
         => new Appointment()
         {
             Id = Guid.Parse("664596ef-c5e2-4b2e-911f-f71ac65d4b8d"),
             StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
             EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
             isCanceled = false,
             DoctorId = Guid.Parse("54475a55-054f-4081-89b3-757cafbd5ea1")
         };

        private bool IsEqualAppointmentEntitiesAndIdentifierAppointmentDTO(Appointment appointment, IdentifiableDTO<AppointmentDTO> identifierAppointmentDTO)
        {
            if (appointment.Id != identifierAppointmentDTO.Id)
                return false;

            if (DateTime.Compare(appointment.StartDateTime, identifierAppointmentDTO.EntityDTO.StartDateTime) != 0)
                return false;

            if (DateTime.Compare(appointment.EndDateTime, identifierAppointmentDTO.EntityDTO.EndDateTime) != 0)
                    return false;

            if (appointment.isCanceled != identifierAppointmentDTO.EntityDTO.isCanceled)
                return false;

            if (appointment.DoctorId != identifierAppointmentDTO.EntityDTO.DoctorId)
                return false;

            return true;
        }
    }
}
