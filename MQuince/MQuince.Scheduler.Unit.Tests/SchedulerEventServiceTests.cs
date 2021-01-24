using MQuince.Scheduler.Application.Services;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Exceptions;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Contracts.Service;
using MQuince.Scheduler.Domain.Events;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Scheduler.Unit.Tests
{
    public class SchedulerEventServiceTests
    {

        IScheduleEventService scheduleEventService;
        IEventRepository eventRepository = Substitute.For<IEventRepository>();
        public SchedulerEventServiceTests()
        {
            scheduleEventService = new ScheduleEventService(eventRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ScheduleEventService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            ScheduleEventService scheduleEventService = new ScheduleEventService(eventRepository);

            Assert.IsType<ScheduleEventService>(scheduleEventService);
        }

        [Fact]
        public void Create_when_give_correctly_dto()
        {
            ScheduleEventDTO scheduleEventDTO = new ScheduleEventDTO()
            {
                EventType = ScheduleEventType.CREATED,
                SessionId = Guid.NewGuid()
            };

            Guid scheduleId = scheduleEventService.Create(scheduleEventDTO);

            Assert.NotEqual(scheduleId.ToString(), Guid.Empty.ToString());
        }

        [Fact]
        public void Create_when_give_incorrectly_dto()
        {
            ScheduleEventDTO scheduleEventDTO = null;

            Assert.Throws<InternalServerErrorException>(() => scheduleEventService.Create(scheduleEventDTO));
        }

        [Fact]
        public void Get_schedule_statistics()
        {
            eventRepository.GetAll().Returns(this.GetScheduleEvents());

            ScheduleEventStatisticsResponseDTO scheduleStatisticsDTO = scheduleEventService.GetScheduleStatistics();

            Assert.Equal(50, scheduleStatisticsDTO.PercentOfSuccessfulCreating);
            Assert.Equal(10.75, scheduleStatisticsDTO.AverageCreatingTime);
            Assert.Equal(1, scheduleStatisticsDTO.StepWherePatientsQuit);
            Assert.Equal(4, scheduleStatisticsDTO.NumberOfCreatedAppointment);
            Assert.Equal(2.2, scheduleStatisticsDTO.AverageTimeOnSpecialization);
            Assert.Equal(1.8, scheduleStatisticsDTO.AverageTimeOnDoctors);
            Assert.Equal(1.33, scheduleStatisticsDTO.AverageTimeOnChooseDate,2);
            Assert.Equal(2.8, scheduleStatisticsDTO.AverageTimeOnChoosePeriod);
            Assert.Equal(4, scheduleStatisticsDTO.NumberOfNotCreatedAppointment);
            Assert.Equal(4.75, scheduleStatisticsDTO.AverageNotCreatedTime);


        }

        private List<ScheduleEvent> GetScheduleEvents()
        {
            List<ScheduleEvent> listOfScheduleEvents = new List<ScheduleEvent>();

            //session 1
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 22, 22, 00, 00), Guid.Parse("bd4d0c93-b074-440f-973d-b9af4b04b8a1"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 22, 22, 00, 07), Guid.Parse("f953c4af-6a55-468a-8370-a18132684744"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTODATEPICKER, new DateTime(2021, 1, 22, 22, 00, 10), Guid.Parse("2d705448-cb4f-4213-adf6-9901bc179777"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDATEPICKERTOPERIOD, new DateTime(2021, 1, 22, 22, 00, 12), Guid.Parse("c0d95935-749e-47d2-a388-ad1c4016cb40"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMPERIODTODATEPICKER, new DateTime(2021, 1, 22, 22, 00, 16), Guid.Parse("9f35b2e1-52b1-4d00-b855-a7a035a0b878"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDATEPICKERTODOCTOR, new DateTime(2021, 1, 22, 22, 00, 17), Guid.Parse("59799e25-df87-41e7-9e77-6665bbfba025"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTOSPEC, new DateTime(2021, 1, 22, 22, 00, 18), Guid.Parse("491ef59d-8fc7-4f0a-8102-e571035b3e2f"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 22, 22, 00, 19), Guid.Parse("a8406f75-b0be-4438-8bd7-c0faece48093"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTODATEPICKER, new DateTime(2021, 1, 22, 22, 00, 20), Guid.Parse("c4f70261-25ff-4739-8b75-c46e000709d0"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDATEPICKERTOPERIOD, new DateTime(2021, 1, 22, 22, 00, 21), Guid.Parse("0ba71052-3736-4007-abd8-2391fa8b9e27"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.CREATED, new DateTime(2021, 1, 22, 22, 00, 25), Guid.Parse("476c6509-88e4-488c-b4a3-58a343b88a3b"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 22, 22, 00, 26), Guid.Parse("d7f6bcad-2c30-4732-95f5-cc6e17dcb28b"), Guid.Parse("9bf98906-f574-41e2-b0c6-427ed2155114")));

            //session2 
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 23, 22, 00, 00), Guid.Parse("accfcc5d-dd02-4cd1-a1ec-e7669b097f68"), Guid.Parse("595acf5d-3c0f-47c1-9c62-aa1caab27bcb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 23, 22, 00, 01), Guid.Parse("bccfcc5d-dd02-4cd1-a1ec-e7669b097f68"), Guid.Parse("595acf5d-3c0f-47c1-9c62-aa1caab27bcb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTODATEPICKER, new DateTime(2021, 1, 23, 22, 00, 03), Guid.Parse("cccfcc5d-dd02-4cd1-a1ec-e7669b097f68"), Guid.Parse("595acf5d-3c0f-47c1-9c62-aa1caab27bcb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDATEPICKERTOPERIOD, new DateTime(2021, 1, 23, 22, 00, 04), Guid.Parse("dccfcc5d-dd02-4cd1-a1ec-e7669b097f68"), Guid.Parse("595acf5d-3c0f-47c1-9c62-aa1caab27bcb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.CREATED, new DateTime(2021, 1, 23, 22, 00, 05), Guid.Parse("eccfcc5d-dd02-4cd1-a1ec-e7669b097f68"), Guid.Parse("595acf5d-3c0f-47c1-9c62-aa1caab27bcb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 23, 22, 00, 06), Guid.Parse("fccfcc5d-dd02-4cd1-a1ec-e7669b097f68"), Guid.Parse("595acf5d-3c0f-47c1-9c62-aa1caab27bcb")));

            //session3
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 24, 22, 00, 00), Guid.Parse("accfcc5d-dd02-4cd1-a1ec-e7669b097f61"), Guid.Parse("b44c564d-b29f-4ade-982e-ffa5da075b75")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 24, 22, 00, 02), Guid.Parse("accfcc5d-dd02-4cd1-a1ec-e7669b097f62"), Guid.Parse("b44c564d-b29f-4ade-982e-ffa5da075b75")));

            //session4
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 25, 22, 00, 00), Guid.Parse("b22c564d-b29f-4ade-982e-ffa5da075b75"), Guid.Parse("372ed600-6a06-41dc-9ed2-4ef276f2395c")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 25, 22, 00, 02), Guid.Parse("333ed600-6a06-41dc-9ed2-4ef276f2395c"), Guid.Parse("372ed600-6a06-41dc-9ed2-4ef276f2395c")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 25, 22, 00, 03), Guid.Parse("344ed600-6a06-41dc-9ed2-4ef276f2395c"), Guid.Parse("372ed600-6a06-41dc-9ed2-4ef276f2395c")));

            //session5
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 25, 22, 00, 00), Guid.Parse("b77c564d-b29f-4ade-982e-ffa5da075b75"), Guid.Parse("9e2265e3-2dc0-475e-aa69-e47c2b676793")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 25, 22, 00, 02), Guid.Parse("b88c564d-b29f-4ade-982e-ffa5da075b75"), Guid.Parse("9e2265e3-2dc0-475e-aa69-e47c2b676793")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 25, 22, 00, 05), Guid.Parse("b99c564d-b29f-4ade-982e-ffa5da075b75"), Guid.Parse("9e2265e3-2dc0-475e-aa69-e47c2b676793")));


            //session6
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 27, 22, 00, 00), Guid.Parse("96753554-e9c0-40b0-92b5-693e541e3cc5"), Guid.Parse("60ec1cdc-8130-4814-b8e7-ef981dc895bb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 27, 22, 00, 02), Guid.Parse("86753554-e9c0-40b0-92b5-693e541e3cc5"), Guid.Parse("60ec1cdc-8130-4814-b8e7-ef981dc895bb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTODATEPICKER, new DateTime(2021, 1, 27, 22, 00, 05), Guid.Parse("76753554-e9c0-40b0-92b5-693e541e3cc5"), Guid.Parse("60ec1cdc-8130-4814-b8e7-ef981dc895bb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDATEPICKERTOPERIOD, new DateTime(2021, 1, 27, 22, 00, 08), Guid.Parse("66753554-e9c0-40b0-92b5-693e541e3cc5"), Guid.Parse("60ec1cdc-8130-4814-b8e7-ef981dc895bb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.CREATED, new DateTime(2021, 1, 27, 22, 00, 13), Guid.Parse("56753554-e9c0-40b0-92b5-693e541e3cc5"), Guid.Parse("60ec1cdc-8130-4814-b8e7-ef981dc895bb")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 27, 22, 00, 14), Guid.Parse("46753554-e9c0-40b0-92b5-693e541e3cc5"), Guid.Parse("60ec1cdc-8130-4814-b8e7-ef981dc895bb")));

            //session7
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 28, 22, 00, 00), Guid.Parse("35d08e34-e423-4d4f-a44c-441b4c5543f2"), Guid.Parse("a2b16098-de2d-4df9-9c21-d140cc71c984")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 28, 22, 00, 03), Guid.Parse("25d08e34-e423-4d4f-a44c-441b4c5543f2"), Guid.Parse("a2b16098-de2d-4df9-9c21-d140cc71c984")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTOSPEC, new DateTime(2021, 1, 28, 22, 00, 05), Guid.Parse("15d08e34-e423-4d4f-a44c-441b4c5543f2"), Guid.Parse("a2b16098-de2d-4df9-9c21-d140cc71c984")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 28, 22, 00, 07), Guid.Parse("45d08e34-e423-4d4f-a44c-441b4c5543f2"), Guid.Parse("a2b16098-de2d-4df9-9c21-d140cc71c984")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 28, 22, 00, 09), Guid.Parse("65d08e34-e423-4d4f-a44c-441b4c5543f2"), Guid.Parse("a2b16098-de2d-4df9-9c21-d140cc71c984")));

            //session8
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.JOIN, new DateTime(2021, 1, 29, 22, 00, 00), Guid.Parse("98c16687-7729-4710-ad6d-13754a6af4ca"), Guid.Parse("09fd14ca-0226-476d-bbfb-8226e2dca008")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMSPECTODOCTOR, new DateTime(2021, 1, 29, 22, 00, 00), Guid.Parse("88c16687-7729-4710-ad6d-13754a6af4ca"), Guid.Parse("09fd14ca-0226-476d-bbfb-8226e2dca008")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDOCTORTODATEPICKER, new DateTime(2021, 1, 29, 22, 00, 00), Guid.Parse("78c16687-7729-4710-ad6d-13754a6af4ca"), Guid.Parse("09fd14ca-0226-476d-bbfb-8226e2dca008")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.FROMDATEPICKERTOPERIOD, new DateTime(2021, 1, 29, 22, 00, 00), Guid.Parse("68c16687-7729-4710-ad6d-13754a6af4ca"), Guid.Parse("09fd14ca-0226-476d-bbfb-8226e2dca008")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.CREATED, new DateTime(2021, 1, 29, 22, 00, 00), Guid.Parse("58c16687-7729-4710-ad6d-13754a6af4ca"), Guid.Parse("09fd14ca-0226-476d-bbfb-8226e2dca008")));
            listOfScheduleEvents.Add(
                new ScheduleEvent(ScheduleEventType.EXIT, new DateTime(2021, 1, 29, 22, 00, 00), Guid.Parse("48c16687-7729-4710-ad6d-13754a6af4ca"), Guid.Parse("09fd14ca-0226-476d-bbfb-8226e2dca008")));


            return listOfScheduleEvents;
        }


    }
}
