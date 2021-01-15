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
            throw new NotImplementedException();
        }
    }
}
