using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>
{
    public override string Path { get; set; }
    public override int LastId { get; set; }
    
    public AppointmentRepository()
    {
        dynamic result = ReadFromAppSettings();
        Path = result.Database.Appointments.Path;
        LastId = result.Database.Appointments.LastId;
    }
    
    public override void ShowInfo(Appointment appointment)
    {
        Console.WriteLine($"{appointment.Doctor}, {appointment.Patient} {appointment.DateTimeFrom}, {appointment.DateTimeTo}");
    }

    protected override void SaveLastId()
    {
        dynamic result = ReadFromAppSettings();
        result.Database.Appointments.LastId = LastId;
        File.WriteAllText(Constants.AppSettingsPath, result.ToString());
    }
}