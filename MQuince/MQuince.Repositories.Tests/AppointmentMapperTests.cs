using MQuince.Entities.Appointment;
using MQuince.Repository.SQL.PersistenceEntities.Appointments;
using System;
using MQuince.Repository.SQL.DataProvider.Util;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MQuince.Enums;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System.Linq;

namespace MQuince.Repositories.Tests
{
    public class AppointmentMapperTests
    {
        [Fact]
        public void Map_appointment_persistence_to_appointment_entity()
        {
            AppointmentPersistence appointmentsPersistance = this.GetAppointmentPersistanceFirst();

            Appointment appointments = AppointmentMapper.MapAppointmentsPersistenceToAppointmentsEntity(appointmentsPersistance);

            Assert.True(this.IsEqualAppointmentPersistanceAndAppointmentEntity(appointmentsPersistance, appointments));
        }

        [Fact]
        public void Map_appointment_persistance_to_appointment_entity_when_persistance_is_null()
        {
            AppointmentPersistence appointmentsPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => AppointmentMapper.MapAppointmentsPersistenceToAppointmentsEntity(appointmentsPersistance));
        }


        [Fact]
        public void Map_appointment_persistance_collection_to_appointment_entity_collection()
        {
            List<AppointmentPersistence> appointmentsPersistance = this.GetListOfAppointmentPersistance();

            List<Appointment> listOfAppointments = AppointmentMapper.MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(appointmentsPersistance).ToList();

            Assert.True(this.IsEqualAppointmentPersistanceAndAppointmentEntity(appointmentsPersistance[0], listOfAppointments[0]));
            Assert.True(this.IsEqualAppointmentPersistanceAndAppointmentEntity(appointmentsPersistance[1], listOfAppointments[1]));
        }

        [Fact]
        public void Map_appointment_persistance_collection_to_appointment_entity_collection_when_collection_is_null()
        {
            List<AppointmentPersistence> listOfAppointmentsPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                    => AppointmentMapper.MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(listOfAppointmentsPersistance));
        }

        private AppointmentPersistence GetAppointmentPersistanceFirst()
                => new AppointmentPersistence()
                {
                    Id = Guid.Parse("54455a55-054f-4081-89b3-757cafbd5ea1"),
                    StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorPersistance = new DoctorPersistence()
                    {
                        Id = Guid.Parse("c84268b1-ca63-45d1-9be1-44976dd1119e"),
                        Name = "Uros",
                        Surname = "Urosevic",
                        Username = "Doctor2",
                        Password = "Doctor2",
                        Jmbg = "7234567890123",
                        Biography = "Test1",
                        Specialization = new SpecializationPersistence() { Id = Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c") }
                    },
                    PatientPersistance = new PatientPersistence()
                    {
                        Id = Guid.Parse("54477a86-094f-4081-89b3-757cafbd5ea1"),
                        Name = "Petar",
                        Surname = "Petrovic",
                        Guest = false,
                        Jmbg = "1234567890123",
                        Password = "patient3",
                        Username = "patient3",
                        DoctorPersistance = new DoctorPersistence()
                        {
                            Id = Guid.Parse("137bda41-c388-4f5b-8016-0105abbd54d0")
                        }
                    }
                };

        private AppointmentPersistence GetAppointmentPersistanceSecond()
                => new AppointmentPersistence()
                {
                    Id = Guid.Parse("c389f917-2eb8-4f1a-a22c-bbc34b137f69"),
                    StartDateTime = new DateTime(2020, 12, 26, 07, 00, 00),
                    EndDateTime = new DateTime(2020, 12, 26, 07, 30, 00),
                    Type = TreatmentType.Examination,
                    DoctorPersistanceId = Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"),
                    PatientPersistanceId = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa")
                };

        private List<AppointmentPersistence> GetListOfAppointmentPersistance()
        {
            List<AppointmentPersistence> listOfSpecificationPersistance = new List<AppointmentPersistence>();
            listOfSpecificationPersistance.Add(this.GetAppointmentPersistanceFirst());
            listOfSpecificationPersistance.Add(this.GetAppointmentPersistanceSecond());
            return listOfSpecificationPersistance;
        }

        private bool IsEqualAppointmentPersistanceAndAppointmentEntity(AppointmentPersistence appointmentPersistence, Appointment appointment)
        {
            if (appointmentPersistence.Id != appointment.Id)
                return false;

            if (!appointmentPersistence.DoctorPersistance.Equals(appointment.DoctorId))
                return false;

            if (!appointmentPersistence.PatientPersistance.Equals(appointment.PatientId))
                return false;

            if (!appointmentPersistence.Type.Equals(appointment.Type))
                return false;

            if (!appointmentPersistence.StartDateTime.Equals(appointment.StartDateTime))
                return false;

            if (!appointmentPersistence.EndDateTime.Equals(appointment.EndDateTime))
                return false;

            return true;
        }
    }
}
