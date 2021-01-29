using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Domain;
using MQuince.Scheduler.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Scheduler.Infrastructure
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DbContextOptions _dbContext;

        public AppointmentRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public void Create(Appointment entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {

                _context.Appointments.Add(AppointmentMapper.MapAppointmentEntityToAppointmentPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AppointmentMapper.MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(_context.Appointments.ToList());
            }
        }

        public IEnumerable<Appointment> GetAppointmentForDoctorForDate(Guid doctorId, DateTime requestDate)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AppointmentMapper.MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(_context.Appointments.ToList())
                                        .Where(x => x.DoctorId.Equals(doctorId) && x.DateRange.StartDateTime.Date.Equals(requestDate.Date) && x.IsCanceled == false);
            }
        }

        public Appointment GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AppointmentMapper.MapAppointmentsPersistenceToAppointmentsEntity(_context.Appointments.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }


        public IEnumerable<Appointment> GetForDoctor(Guid doctorId)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AppointmentMapper.MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(_context.Appointments.Where(c => c.Id.Equals(doctorId) && c.IsCanceled == false));
            }
        }

        public IEnumerable<Appointment> GetForPatient(Guid patientId)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AppointmentMapper.MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(_context.Appointments.Where(c => c.PatientPersistanceId == patientId && c.IsCanceled == false).ToList());
            }
        }

        public void Update(Appointment entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Appointments.Update(AppointmentMapper.MapAppointmentEntityToAppointmentPersistence(entity));
                _context.SaveChanges();
            }
        }
    }
}
