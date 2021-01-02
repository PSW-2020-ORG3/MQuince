using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.DTO
{
	public class AppointmentDTO
	{
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
