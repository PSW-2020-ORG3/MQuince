using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Contracts.Service;
using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Services
{
    public class ScheduleEventService : IScheduleEventService
    {
        private IEventRepository _eventRepository;
        public ScheduleEventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository == null ? throw new ArgumentNullException(nameof(eventRepository) + "is set to null") : eventRepository;
        }
        public Guid Create(ScheduleEventDTO entityDTO)
        {
            ScheduleEvent scheduleEvent = new ScheduleEvent(entityDTO.EventType, Guid.NewGuid(), entityDTO.SessionId);
            _eventRepository.Create(scheduleEvent);
            return Guid.NewGuid();
        }

        public ScheduleEventStatisticsResponseDTO GetScheduleStatistics()
        {
            List<ScheduleEvent> listOfEvents = _eventRepository.GetAll().ToList();

            Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession = this.GenerateDictionaryPerSession(listOfEvents);

            ScheduleEventStatisticsResponseDTO scheduleStatisticsResponseDTO = new ScheduleEventStatisticsResponseDTO();
            scheduleStatisticsResponseDTO.PercentOfSuccessfulCreating = this.GetPercentOfSuccessfulCreating(mapOfEventsPerSession);
            scheduleStatisticsResponseDTO.AverageCreatingTime = this.GetAverageCreatingTime(mapOfEventsPerSession);
            scheduleStatisticsResponseDTO.StepWherePatientsQuit = this.GetStepWherePatientsMostQuit(mapOfEventsPerSession);

            return scheduleStatisticsResponseDTO;
        }

        private int GetStepWherePatientsMostQuit(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            Dictionary<int, int> mapOfMostQuit = new Dictionary<int, int>();
            mapOfMostQuit[0] = 0;
            mapOfMostQuit[1] = 0;
            mapOfMostQuit[2] = 0;
            mapOfMostQuit[3] = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                if (!this.IsCreatedAppointmentInThisSession(sessionEvent.Value))
                {
                    int step = CheckStepWherePatientQuit(sessionEvent.Value);
                    mapOfMostQuit[step]++;
                }
            }

            return mapOfMostQuit.Aggregate((x, y) => x.Value > y.Value ? x : y).Key; 
        }

        private int CheckStepWherePatientQuit(List<ScheduleEvent> scheduleEventsInSession)
        {
            scheduleEventsInSession.Sort((x, y) => DateTime.Compare(y.TimeStamp, x.TimeStamp));

            ScheduleEventType typeEventBeforeQuit = scheduleEventsInSession[1].EventType;

            if (typeEventBeforeQuit == ScheduleEventType.JOIN || typeEventBeforeQuit == ScheduleEventType.FROMDOCTORTOSPEC)
                return 0; 
            else if(typeEventBeforeQuit == ScheduleEventType.FROMSPECTODOCTOR || typeEventBeforeQuit == ScheduleEventType.FROMDATEPICKERTODOCTOR)
                return 1;
            else if (typeEventBeforeQuit == ScheduleEventType.FROMDOCTORTODATEPICKER || typeEventBeforeQuit == ScheduleEventType.FROMPERIODTODATEPICKER)
                return 2;
            else
                return 3;
        }

        private double GetAverageCreatingTime(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double numberOfCreatedAppointment = 0;
            double sumMinutesForCreate = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                if (this.IsCreatedAppointmentInThisSession(sessionEvent.Value))
                {
                    numberOfCreatedAppointment++;
                    sumMinutesForCreate += GetMinutesForCreateAppointment(sessionEvent.Value);
                }
            }

            return sumMinutesForCreate / numberOfCreatedAppointment;
        }

        private double GetMinutesForCreateAppointment(List<ScheduleEvent> scheduleEventsInSession)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            foreach (ScheduleEvent scheduleEvent in scheduleEventsInSession)
            {
                if (scheduleEvent.EventType == ScheduleEventType.CREATED)
                    endDate = scheduleEvent.TimeStamp;
                else if (scheduleEvent.EventType == ScheduleEventType.JOIN)
                    startDate = scheduleEvent.TimeStamp;
            }

            return endDate.Subtract(startDate).TotalMinutes;
        }

        private double GetPercentOfSuccessfulCreating(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double numberOfCreatedAppointment = 0;
            double numberOfTriesToCreateAppointment = 0;

            foreach(var sessionEvent in mapOfEventsPerSession)
            {
                numberOfTriesToCreateAppointment++;
                if (this.IsCreatedAppointmentInThisSession(sessionEvent.Value))
                    numberOfCreatedAppointment++;
            }

            return numberOfCreatedAppointment / numberOfTriesToCreateAppointment * 100;
        }

        private bool IsCreatedAppointmentInThisSession(List<ScheduleEvent> scheduleEventsInSession)
        {
            foreach (ScheduleEvent scheduleEvent in scheduleEventsInSession)
            {
                if (scheduleEvent.EventType == ScheduleEventType.CREATED)
                    return true;
            }

            return false;
        }

        private Dictionary<Guid, List<ScheduleEvent>> GenerateDictionaryPerSession(List<ScheduleEvent> listOfEvents)
        {
            Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession = new Dictionary<Guid, List<ScheduleEvent>>();

            foreach(ScheduleEvent scheduleEvent in listOfEvents)
            {
                if (!mapOfEventsPerSession.ContainsKey(scheduleEvent.SessionId))
                {
                    mapOfEventsPerSession[scheduleEvent.SessionId] = new List<ScheduleEvent>();
                    mapOfEventsPerSession[scheduleEvent.SessionId].Add(scheduleEvent);
                    continue;
                }

                mapOfEventsPerSession[scheduleEvent.SessionId].Add(scheduleEvent);
            }

            return mapOfEventsPerSession;
        }
    }
}
