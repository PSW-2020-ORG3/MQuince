using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Contracts
{
	public interface IAppointmentService : IService<AppointmentDTO, IdentifiableDTO<AppointmentDTO>>
	{
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForDoctor(Guid doctorId);
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId);
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime date);
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time);
		bool CancelAppointment(Guid appointmentId);
	}
}
