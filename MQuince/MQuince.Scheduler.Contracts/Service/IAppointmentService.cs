using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Contracts.DTO;
using System;
using System.Collections.Generic;

namespace MQuince.Scheduler.Contracts.Service
{
	public interface IAppointmentService : IService<AppointmentDTO, IdentifiableDTO<AppointmentDTO>>
	{
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForDoctor(Guid doctorId);
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId);
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime date);
		IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time);
		IdentifiableDTO<ReportDTO> GetReportForAppointment(Guid id);
		bool CancelAppointment(Guid appointmentId);
	}
}
