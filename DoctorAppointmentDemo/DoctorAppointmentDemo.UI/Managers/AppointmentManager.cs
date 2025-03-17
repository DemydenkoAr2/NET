using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo.UI.Managers;

public class AppointmentManager
{
    private readonly IAppointmentService _appointmentService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    public AppointmentManager(IAppointmentService appointmentService, IDoctorService doctorService,
        IPatientService patientService)
    {
        _appointmentService = appointmentService;
        _doctorService = doctorService;
        _patientService = patientService;
    }
    
    public void AddAppointment()
    {
        var appointment = SetAppointmentFromInput();
        _appointmentService.Create(appointment);
        Console.WriteLine("Appointment added successfully.");
    }

    public void ListAppointment()
    {
        var appointments = _appointmentService.GetAll();
        foreach (var appointment in appointments)
        {
            string patientName = appointment.Patient?.Name ?? "Unknown Patient";
            string doctorName = appointment.Doctor?.Name ?? "Unknown Doctor";

            Console.WriteLine($"Id: {appointment.Id}, Patient: {patientName}, Doctor: {doctorName}");
            Console.WriteLine("");
        }
    }

    public void UpdateAppointment()
    {
        int id = ConsoleHelper.ReadInt("Enter Appointment ID: ");
        var appointment = SetAppointmentFromInput();
        _appointmentService.Update(id, appointment);
        Console.WriteLine("Appointment updated successfully.");
    }

    public void DeleteAppointment()
    {
        int id = ConsoleHelper.ReadInt("Enter Appointment ID: ");
        bool isDeleted = _appointmentService.Delete(id);
        Console.WriteLine(isDeleted ? "Appointment deleted successfully." : "Appointment not found.");
    }

    private Appointment SetAppointmentFromInput()
    {
        int patientId = ConsoleHelper.ReadInt("Enter Patient ID: ");
        int doctorId = ConsoleHelper.ReadInt("Enter Doctor ID: ");
        
        DateTime dateTimeFrom;
        while (true)
        {
            Console.Write("Enter date and time (format: dd/MM/yyyy HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out dateTimeFrom))
            {
                break;
            }
            Console.WriteLine("Invalid date format. Please try again.");
        }
            
        DateTime dateTimeTo;
        while (true)
        {
            Console.Write("Enter date and time (format: dd/MM/yyyy HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out dateTimeTo))
            {
                break;
            }
            Console.WriteLine("Invalid date format. Please try again.");
        }
            
        DateTime createdAt = DateTime.Today;
        DateTime updatedAt = DateTime.Today;
        
        string description = ConsoleHelper.ReadString("Enter Description: ");
        
        return new Appointment
        {
            Doctor = _doctorService.Get(doctorId),
            Patient = _patientService.Get(patientId),
            DateTimeFrom = dateTimeFrom,
            DateTimeTo = dateTimeTo,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Description = description,
        };
    }
}