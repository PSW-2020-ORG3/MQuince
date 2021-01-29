using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Exceptions;
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
            try
            {
                ScheduleEvent scheduleEvent = new ScheduleEvent(entityDTO.EventType, Guid.NewGuid(), entityDTO.SessionId);
                _eventRepository.Create(scheduleEvent);
                return scheduleEvent.BaseEntityId;
            }catch(Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

        public ScheduleEventStatisticsResponseDTO GetScheduleStatistics()
        {
            try
            {
                List<ScheduleEvent> listOfEvents = _eventRepository.GetAll().ToList();

                Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession = this.GenerateDictionaryPerSession(listOfEvents);

                ScheduleEventStatisticsResponseDTO scheduleStatisticsResponseDTO = new ScheduleEventStatisticsResponseDTO();
                scheduleStatisticsResponseDTO.PercentOfSuccessfulCreating = this.GetPercentOfSuccessfulCreating(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.AverageCreatingTime = this.GetAverageCreatingTime(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.AverageNotCreatedTime = this.GetAverageNotCreatedTime(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.StepWherePatientsQuit = this.GetStepWherePatientsMostQuit(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.NumberOfCreatedAppointment = this.GetNumberOfCreatedAppoitment(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.NumberOfNotCreatedAppointment = this.GetNumberNotCreatedAppoitment(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.AverageTimeOnSpecialization = this.GetAverageTimeOnSpecialization(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.AverageTimeOnDoctors = this.GetAverageTimeOnDoctors(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.AverageTimeOnChooseDate = this.GetAverageTimeOnChooseDate(mapOfEventsPerSession);
                scheduleStatisticsResponseDTO.AverageTimeOnChoosePeriod = this.GetAverageTimeOnChoosePeriod(mapOfEventsPerSession);

                return scheduleStatisticsResponseDTO;
            }catch(Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

        private int GetNumberNotCreatedAppoitment(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            int numberOfNotCreatedAppointment = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                if (!this.IsCreatedAppointmentInThisSession(sessionEvent.Value))
                    numberOfNotCreatedAppointment++;
            }

            return numberOfNotCreatedAppointment;
        }

        private Tuple<double, double> GetAverageTimeOnPageAtDateChoose(List<ScheduleEvent> scheduleEventsInSession)
        {
            scheduleEventsInSession.Sort((x, y) => DateTime.Compare(x.TimeStamp, y.TimeStamp));

            double sumOfTimesOnDateChoosePage = 0;
            double numberOfTimesDateChoosePage = 0;

            for (int i = 0; i < scheduleEventsInSession.Count; i++)
            {
                if (scheduleEventsInSession.ElementAtOrDefault(i + 1) == null)
                    break;

                if (scheduleEventsInSession[i].EventType == ScheduleEventType.FROMDATEPICKERTOPERIOD)
                {
                    sumOfTimesOnDateChoosePage += GetTimeBeetwenTwoEvents(scheduleEventsInSession[i + 1].TimeStamp, scheduleEventsInSession[i].TimeStamp);
                    numberOfTimesDateChoosePage++;
                }
            }

            return Tuple.Create(sumOfTimesOnDateChoosePage, numberOfTimesDateChoosePage);
        }

        private double GetAverageTimeOnChoosePeriod(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double sumOfTimesOnChoosePeriod = 0;
            double numberOfLocatedOnChoosePeriod = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                Tuple<double, double> averageTimesOnChoosePeriod = GetAverageTimeOnPageAtDateChoose(sessionEvent.Value);
                sumOfTimesOnChoosePeriod += averageTimesOnChoosePeriod.Item1;
                numberOfLocatedOnChoosePeriod += averageTimesOnChoosePeriod.Item2;
            }

            return sumOfTimesOnChoosePeriod / numberOfLocatedOnChoosePeriod;
        }

        private double GetAverageTimeOnChooseDate(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double sumOfTimesOnChooseDate = 0;
            double numberOfLocatedOnChooseDate = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                Tuple<double, double> averageTimesOnChooseDate = GetAverageTimeOnPageAtOneSession(sessionEvent.Value, ScheduleEventType.FROMDOCTORTODATEPICKER, ScheduleEventType.FROMPERIODTODATEPICKER);
                sumOfTimesOnChooseDate += averageTimesOnChooseDate.Item1;
                numberOfLocatedOnChooseDate += averageTimesOnChooseDate.Item2;
            }

            return sumOfTimesOnChooseDate / numberOfLocatedOnChooseDate;
        }

        private double GetAverageTimeOnSpecialization(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double sumOfTimesOnSpecialization = 0;
            double numberOfLocatedOnSpecialization = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                Tuple<double, double> averageTimesOnSpecializations = GetAverageTimeOnPageAtOneSession(sessionEvent.Value, ScheduleEventType.JOIN, ScheduleEventType.FROMDOCTORTOSPEC);
                sumOfTimesOnSpecialization += averageTimesOnSpecializations.Item1;
                numberOfLocatedOnSpecialization += averageTimesOnSpecializations.Item2;
            }

            return sumOfTimesOnSpecialization / numberOfLocatedOnSpecialization;
        }

        private double GetAverageTimeOnDoctors(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double sumOfTimesOnDoctors = 0;
            double numberOfTimesDoctors = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                Tuple<double, double> averageTimesOnDoctors = GetAverageTimeOnPageAtOneSession(sessionEvent.Value, ScheduleEventType.FROMSPECTODOCTOR, ScheduleEventType.FROMDATEPICKERTODOCTOR);
                sumOfTimesOnDoctors += averageTimesOnDoctors.Item1;
                numberOfTimesDoctors += averageTimesOnDoctors.Item2;
            }

            return sumOfTimesOnDoctors / numberOfTimesDoctors;
        }

        private Tuple<double, double> GetAverageTimeOnPageAtOneSession(List<ScheduleEvent> scheduleEventsInSession, ScheduleEventType toJoin, ScheduleEventType toComeBack)
        {
            scheduleEventsInSession.Sort((x, y) => DateTime.Compare(x.TimeStamp, y.TimeStamp));

            double sumOfTimesOnPage = 0;
            double numberOfTimesOnPage = 0;

            for (int i = 0; i < scheduleEventsInSession.Count; i++)
            {
                if (scheduleEventsInSession.ElementAtOrDefault(i + 1) == null)
                    break;

                if (scheduleEventsInSession[i].EventType == toJoin || scheduleEventsInSession[i].EventType == toComeBack)
                {
                    sumOfTimesOnPage += GetTimeBeetwenTwoEvents(scheduleEventsInSession[i + 1].TimeStamp, scheduleEventsInSession[i].TimeStamp);
                    numberOfTimesOnPage++;
                }
            }

            return Tuple.Create(sumOfTimesOnPage, numberOfTimesOnPage);
        }

        private double GetTimeBeetwenTwoEvents(DateTime endDate, DateTime startDate)
        {
            if (endDate > startDate)
            {
                return endDate.Subtract(startDate).TotalSeconds;
            }
            return 0;
        }

        private int GetNumberOfCreatedAppoitment(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            int numberOFCreatedAppointment = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                if (this.IsCreatedAppointmentInThisSession(sessionEvent.Value))
                    numberOFCreatedAppointment++;
            }

            return numberOFCreatedAppointment;
        }

        private int GetStepWherePatientsMostQuit(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            Dictionary<int, int> mapOfMostQuit = new Dictionary<int, int>() { { 0, 0 },{ 1, 0 },{ 2, 0 },{ 3, 0 } } ;

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

            if (scheduleEventsInSession.ElementAtOrDefault(1) == null)
                return 0;

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
                    sumMinutesForCreate += GetTimeForCreateAppointment(sessionEvent.Value);
                }
            }

            return sumMinutesForCreate / numberOfCreatedAppointment;
        }

        private double GetAverageNotCreatedTime(Dictionary<Guid, List<ScheduleEvent>> mapOfEventsPerSession)
        {
            double numberOfCreatedAppointment = 0;
            double sumMinutesForCreate = 0;

            foreach (var sessionEvent in mapOfEventsPerSession)
            {
                if (!this.IsCreatedAppointmentInThisSession(sessionEvent.Value))
                {
                    numberOfCreatedAppointment++;
                    sumMinutesForCreate += GetTimeForNotCreateAppointment(sessionEvent.Value);
                }
            }

            return sumMinutesForCreate / numberOfCreatedAppointment;
        }

        private double GetTimeForCreateAppointment(List<ScheduleEvent> scheduleEventsInSession)
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

            return GetTimeBeetwenTwoEvents(endDate, startDate);
        }

        private double GetTimeForNotCreateAppointment(List<ScheduleEvent> scheduleEventsInSession)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            foreach (ScheduleEvent scheduleEvent in scheduleEventsInSession)
            {
                if (scheduleEvent.EventType == ScheduleEventType.EXIT)
                    endDate = scheduleEvent.TimeStamp;
                else if (scheduleEvent.EventType == ScheduleEventType.JOIN)
                    startDate = scheduleEvent.TimeStamp;
            }

            return GetTimeBeetwenTwoEvents(endDate, startDate);
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
