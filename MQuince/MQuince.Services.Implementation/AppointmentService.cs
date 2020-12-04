using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        public Guid Create(AppointmentDTO entityDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IdentifiableDTO<AppointmentDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForDoctor(Guid doctorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public void Update(AppointmentDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
