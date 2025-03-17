using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo.UI.Managers;

public class DoctorManager
{
    private readonly IDoctorService _doctorService;

    public DoctorManager(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public void AddDoctor()
    {
        var doctor = SetDoctorFromInput();
        _doctorService.Create(doctor);
        Console.WriteLine("Doctor added successfully.");
    }

    public void ListDoctors()
    {
        var doctors = _doctorService.GetAll();
        foreach (var doctor in doctors)
        {
            Console.WriteLine($"Id: {doctor.Id}, Name: {doctor.Name}, Lastname: {doctor.Surname}, Type: {doctor.DoctorType}");
        }
    }

    public void UpdateDoctor()
    {
        int id = ConsoleHelper.ReadInt("Enter Doctor ID: ");
        var doctor = SetDoctorFromInput();
        _doctorService.Update(id, doctor);
        Console.WriteLine("Doctor updated successfully.");
    }

    public void DeleteDoctor()
    {
        int id = ConsoleHelper.ReadInt("Enter Doctor ID: ");
        bool isDeleted = _doctorService.Delete(id);
        Console.WriteLine(isDeleted ? "Doctor deleted successfully." : "Doctor not found.");
    }

    private static Doctor SetDoctorFromInput()
    {
        string name = ConsoleHelper.ReadString("Name: ");
        string surname = ConsoleHelper.ReadString("Last name: ");
        string email = ConsoleHelper.ReadString("Email: ");
        string phone = ConsoleHelper.ReadString("Phone: ");
        var doctorType = ConsoleHelper.ReadEnum<DoctorTypes>("Choose doctor type:");

        byte experience = (byte)ConsoleHelper.ReadInt("Experience: ");
        decimal salary = (decimal)ConsoleHelper.ReadInt("Salary: ");

        return new Doctor
        {
            Name = name,
            Surname = surname,
            Email = email,
            Phone = phone,
            Experience = experience,
            Salary = salary,
            DoctorType = doctorType,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}