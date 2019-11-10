using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAS.Models;

namespace DAS
{
    class DataBaseContext: DbContext
    {
        public DataBaseContext() { }

        public DbSet<ScheduleDayRel> ScheduleDayRels { get; set; }
        public DbSet<HospitalType> HospitalTypes { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ConfirmedAppointment> ConfirmedAppointments { get; set; }
        public DbSet<TransactionDetails> TransactionDetails { get; set; }
        public DbSet<PaitentHistory> PaitentHistorys { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<BloodDonor> BloodDonors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<DAS.Models.ViewModel.DoctorRegistration> DoctorRegistrations { get; set; }
    }
}
