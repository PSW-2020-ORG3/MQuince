using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.DTO
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
