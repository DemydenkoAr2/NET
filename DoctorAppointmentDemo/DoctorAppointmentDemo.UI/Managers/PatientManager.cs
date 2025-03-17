using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo.UI.Managers;

public class PatientManager
{
    private readonly IPatientService _patientService;

    public PatientManager(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public void AddPatient()
    {
        var patient = SetPatientFromInput();
        _patientService.Create(patient);
        Console.WriteLine("Patient added successfully.");
    }

    public void ListPatients()
    {
        var patients = _patientService.GetAll();
        foreach (var patient in patients)
        {
            Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}");
        }
    }

    public void UpdatePatient()
    {
        int id = ConsoleHelper.ReadInt("Enter Patient ID: ");
        var patient = SetPatientFromInput();
        _patientService.Update(id, patient);
        Console.WriteLine("Patient updated successfully.");
    }

    public void DeletePatient()
    {
        int id = ConsoleHelper.ReadInt("Enter Doctor ID: ");
        bool isDeleted = _patientService.Delete(id);
        Console.WriteLine(isDeleted ? "Patient deleted successfully." : "Patient not found.");
    }

    private static Patient SetPatientFromInput()
    {
        string name = ConsoleHelper.ReadString("Name: ");
        string surname = ConsoleHelper.ReadString("Last name: ");
        string email = ConsoleHelper.ReadString("Email: ");
        string phone = ConsoleHelper.ReadString("Phone: ");
        var illness = ConsoleHelper.ReadEnum<IllnessTypes>("Choose illness type:");

        return new Patient
        {
            Name = name,
            Surname = surname,
            Email = email,
            Phone = phone,
            IllnessType = illness,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}