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
                        Id = Guid.Parse("90450920-986a-42f4-89c2-a8a4e1a25151")
                    },
                    PatientPersistance = new PatientPersistence()
                    {
                        Id = Guid.Parse("6459c216-1770-41eb-a56a-7f4524728546")
                    }
                };

        private AppointmentPersistence GetAppointmentPersistanceSecond()
                => new AppointmentPersistence()
                {
                    Id = Guid.Parse("c389f917-3eb8-4f1a-a22c-bbc34b137f69")
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
