﻿using System.Threading.Channels;
using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
             Console.WriteLine($"Id: {doctor.Id}, Name: {doctor.Name}, " +
                               $"Doctor Type: {doctor.DoctorType}, " +
                               $"Email: {doctor.Email}, Phone: {doctor.Phone}, " +
                               $"Experience: {doctor.Experience}");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
