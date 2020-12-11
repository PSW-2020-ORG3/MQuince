using MQuince.Entities.Appointment;
using MQuince.Enums;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class DoctorPriorityStrategy : IStrategy
    {
        public RecommendAppointmentParameters _parameters;
        public IAppointmentService _appointmentService;

        public DoctorPriorityStrategy(IAppointmentService appointmentService, RecommendAppointmentParameters parameters)
        {
            _appointmentService = appointmentService;
            _parameters = parameters;
        }

        public AppointmentDTO recommend(Guid patientId, Guid doctorId)
        {
            List<AppointmentDTO> freeAppointments = new List<AppointmentDTO>(); 
            DateTime date = _parameters.DateTo.Date;
            DateTime dateUpperLimit = date.AddDays(100);
            while (date < dateUpperLimit)
            {
                TreatmentType treatmentType = TreatmentType.Examination;
                freeAppointments = (List<AppointmentDTO>)_appointmentService.GetFreeAppointments(patientId, doctorId, date, treatmentType);
                if (freeAppointments.Count > 0)
                {
                    return freeAppointments[0];
                }
                date = date.AddDays(1);
            }
            return null;
        }
    }
}
