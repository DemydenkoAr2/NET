using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using Constants = DoctorAppointmentDemo.Data.Configuration.Constants;

namespace DoctorAppointmentDemo.Data.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public override string Path { get; set; }
    public override int LastId { get; set; }
    
    public PatientRepository()
    {
        dynamic result = ReadFromAppSettings();
        Path = result.Database.Patients.Path;
        LastId = result.Database.Patients.LastId;
    }
    
    public override void ShowInfo(Patient patient)
    {
        Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name},{patient.Email}, Phone: {patient.Phone}");
    }

    protected override void SaveLastId()
    {
        dynamic result = ReadFromAppSettings();
        result.Database.Patients.LastId = LastId;

        File.WriteAllText(Constants.AppSettingsPath, result.ToString());
    }
}