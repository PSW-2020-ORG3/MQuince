using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class WorkTimeServiceTests
    {
        IWorkTimeService workTimeService;
        IWorkTimeRepository workTimeRepository = Substitute.For<IWorkTimeRepository>();

        public WorkTimeServiceTests()
        {
            workTimeService = new WorkTimeService(workTimeRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new WorkTimeService(null));
        }



        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IWorkTimeService workTimeService = new WorkTimeService(workTimeRepository);

            Assert.IsType<WorkTimeService>(workTimeService);
        }

        [Fact]
        public void Get_work_times_for_doctor_return_doctors()
        {
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba")).Returns(this.GetListOfWorkTimes());

            List<WorkTime> workTimes = workTimeService.GetWorkTimesForDoctor(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba")).ToList();

            Assert.True(this.CompareWorkTimes(this.GetFirstWorkTime(), workTimes[0]));
            Assert.True(this.CompareWorkTimes(this.GetSecondWorkTime(), workTimes[1]));

        }

        [Fact]
        public void Get_work_times_for_doctor_returns_null()
        {
            List<WorkTime> workTimes  = null;
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(workTimes);

            Assert.Throws<ArgumentNullException>(()=> workTimeService.GetWorkTimesForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).ToList());
        }

        [Fact]
        public void Get_work_times_for_doctor_returns_any_argument_null_exception()
        {
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => workTimeService.GetWorkTimesForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_work_times_for_doctor_returns_any_other_exception()
        {
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => workTimeService.GetWorkTimesForDoctor(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_work_time_for_doctor_for_date_return_doctors()
        {
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba")).Returns(this.GetListOfWorkTimes());
            DateTime date = new DateTime(2020, 12, 05);

            WorkTime workTime = workTimeService.GetWorkTimeForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date);

            Assert.True(this.CompareWorkTimesForDoctorForDate(this.GetFirstWorkTime(), workTime, date));
        }

        [Fact]
        public void Get_work_time_for_doctor_for_date_when_doctor_has_not_worktime()
        {
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba")).Returns(this.GetListOfWorkTimes());
            DateTime date = new DateTime(2020, 11, 05);

            WorkTime workTime = workTimeService.GetWorkTimeForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date);

            Assert.Null(workTime);
        }

        [Fact]
        public void Get_work_time_for_doctor_for_date_returns_any_exception()
        {
            workTimeRepository.GetWorkTimesForDoctor(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba")).Returns(x => { throw new Exception(); });
            DateTime date = new DateTime(2020, 11, 05);

            Assert.Throws<InternalServerErrorException>(() => workTimeService.GetWorkTimeForDoctorForDate(Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"), date));
        }

        private WorkTime GetFirstWorkTime()
                => new WorkTime(Guid.Parse("6a3d67e0-6af6-4947-919f-7a1a80023db3"), new DateTime(2020, 12, 01), new DateTime(2020, 12, 22), 8, 14, Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"));


        private WorkTime GetSecondWorkTime()
           => new WorkTime(Guid.Parse("c1d9ae05-81aa-4203-a830-692383bfca09"), new DateTime(2020, 12, 23), new DateTime(2020, 12, 27), 14, 20, Guid.Parse("7bb28807-f41e-4bf4-b699-6a478051adba"));


        private List<WorkTime> GetListOfWorkTimes()
        {
            List<WorkTime> listOfWorkTime = new List<WorkTime>();
            listOfWorkTime.Add(this.GetFirstWorkTime());
            listOfWorkTime.Add(this.GetSecondWorkTime());
            return listOfWorkTime;
        }

        private bool CompareWorkTimes(WorkTime firstWorkTime, WorkTime secondWorkTime)
        {
            if (firstWorkTime.Id != secondWorkTime.Id)
                return false;

            if (firstWorkTime.StartDate != secondWorkTime.StartDate)
                return false;

            if (firstWorkTime.EndDate != secondWorkTime.EndDate)
                return false;

            if (firstWorkTime.StartTime != secondWorkTime.StartTime)
                return false;

            if (firstWorkTime.EndTime != secondWorkTime.EndTime)
                return false;

            if (firstWorkTime.DoctorId != secondWorkTime.DoctorId)
                return false;

            return true;
        }

        private bool CompareWorkTimesForDoctorForDate(WorkTime firstWorkTime, WorkTime secondWorkTime, DateTime date)
        {
            if (firstWorkTime.Id != secondWorkTime.Id)
                return false;

            if (secondWorkTime.StartDate != date)
                return false;

            if (secondWorkTime.EndDate != date)
                return false;

            if (firstWorkTime.StartTime != secondWorkTime.StartTime)
                return false;

            if (firstWorkTime.EndTime != secondWorkTime.EndTime)
                return false;

            if (firstWorkTime.DoctorId != secondWorkTime.DoctorId)
                return false;

            return true;
        }

    }
}
