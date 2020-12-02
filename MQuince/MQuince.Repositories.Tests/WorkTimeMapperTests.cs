﻿using MQuince.Entities.Users;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Repositories.Tests
{
    public class WorkTimeMapperTests
    {
        [Fact]
        public void Map_worktime_persistence_to_work_time_entity()
        {
            WorkTimePersistence workTimePersistence = this.GetWorkTimePersistanceFirst();

            WorkTime workTime = WorkTimeMapper.MapWorkTimePersistenceToWorkTimeEntity(workTimePersistence);

            Assert.True(IsEqualWorkTimePersistanceAndWorkTimeEntity(workTimePersistence, workTime));

        }


        [Fact]
        public void Map_worktime_persistence_to_work_time_entity_when_persistance_is_null()
        {
            WorkTimePersistence workTimePersistence = null;

            Assert.Throws<ArgumentNullException>(()
                             => WorkTimeMapper.MapWorkTimePersistenceToWorkTimeEntity(workTimePersistence));
        }

        [Fact]
        public void Map_worktime_persistence_collection_to_worktime_entity_collection()
        {
            List<WorkTimePersistence> listOfPersistance = this.GetListOfWorkTimePersistance();

            List<WorkTime> listOfWorkTime = WorkTimeMapper.MapWorkTimePersistenceCollectionToWorkTimeEntityCollection(listOfPersistance).ToList();

            Assert.True(IsEqualWorkTimePersistanceAndWorkTimeEntity(listOfPersistance[0], listOfWorkTime[0]));
            Assert.True(IsEqualWorkTimePersistanceAndWorkTimeEntity(listOfPersistance[1], listOfWorkTime[1]));
        }


        [Fact]
        public void Map_worktime_persistence_collection_to_worktime_entity_collection_when_persistance_collection_is_null()
        {
            List<WorkTimePersistence> listOfPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                             => WorkTimeMapper.MapWorkTimePersistenceCollectionToWorkTimeEntityCollection(listOfPersistance));
        }

        private WorkTimePersistence GetWorkTimePersistanceFirst()
                => new WorkTimePersistence()
                {
                    Id = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a"),
                    StartDate = new DateTime(2020,12,01),
                    EndDate= new DateTime(2020,12,22),
                    StartTime=8,
                    EndTime=14,
                    Doctor = this.GetDoctorPersistanceFirst()
                };

        private WorkTimePersistence GetWorkTimePersistanceSecond()
            => new WorkTimePersistence()
            {
                Id = Guid.Parse("c1d9ae05-81aa-4203-a830-692383bfca09"),
                StartDate = new DateTime(2010, 11, 01),
                EndDate = new DateTime(2010, 11, 25),
                StartTime = 14,
                EndTime = 20,
                Doctor = this.GetDoctorPersistanceSecond()
             };

        private List<WorkTimePersistence> GetListOfWorkTimePersistance()
        {
            List<WorkTimePersistence> listOfWorkTimePersistance = new List<WorkTimePersistence>();
            listOfWorkTimePersistance.Add(this.GetWorkTimePersistanceFirst());
            listOfWorkTimePersistance.Add(this.GetWorkTimePersistanceSecond());
            return listOfWorkTimePersistance;
        }
        private DoctorPersistence GetDoctorPersistanceFirst()
                => new DoctorPersistence()
                {
                    Id = Guid.Parse("22bd31z1-1361-4c06-9751-9666ce10d30a"),
                };

        private DoctorPersistence GetDoctorPersistanceSecond()
                => new DoctorPersistence()
                {
                    Id = Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"),
                };

        private bool IsEqualWorkTimePersistanceAndWorkTimeEntity(WorkTimePersistence workTimePersistence, WorkTime workTime)
        {
            if (workTimePersistence.Id != workTime.Id)
                return false;

            if (workTimePersistence.StartDate != workTime.StartDate)
                return false;

            if (workTimePersistence.EndDate != workTime.EndDate)
                return false;

            if (workTimePersistence.StartTime != workTime.StartTime)
                return false;

            if (workTimePersistence.EndTime != workTime.EndTime)
                return false;

            if (workTimePersistence.Doctor.Id != workTime.DoctorId)
                return false;

            return true;
        }
    }
}