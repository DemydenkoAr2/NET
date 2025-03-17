using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI.Managers;

namespace DoctorAppointmentDemo.UI
{
    public static class Program
    {
        private static IDoctorService _doctorService;
        private static IAppointmentService _appointmentService;
        private static IPatientService _patientService;
        
        private static DoctorManager _doctorManager;
        private static PatientManager _patientManager;
        private static AppointmentManager _appointmentManager;
        public static void Main()
        {
            InitializeServices();
            bool isRunning = true;
            
            while (isRunning)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Doctors | 2. Patients | 3. Appointments | 0. Exit");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch ((Menu)choice)
                    {
                        case Menu.ManageDoctors:
                            ManageDoctors();
                            break;
                        case Menu.ManagePatients:
                            ManagePatients();
                            break;
                        case Menu.ManageAppointments:
                            ManageAppointments();
                            break;
                        case Menu.Exit:
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Wrong choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice, please try again.");
                }
            }
        }
        
        private static void InitializeServices()
        {
            var doctorService = new DoctorService(new DoctorRepository());
            var patientService = new PatientService(new PatientRepository());
            var appointmentService = new AppointmentService(new AppointmentRepository());

            _doctorManager = new DoctorManager(doctorService);
            _patientManager = new PatientManager(patientService);
            _appointmentManager = new AppointmentManager(appointmentService, doctorService, patientService);
        }
        private static void ManageDoctors()
        {
            Console.WriteLine("1. Add | 2. Get list of doctors | 3. Update doctor | 4. Delete doctor | 0. Back: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        _doctorManager.AddDoctor();
                        break;
                    case 2:
                        _doctorManager.ListDoctors();
                        break;
                    case 3:
                        _doctorManager.UpdateDoctor();
                        break;
                    case 4:
                        _doctorManager.DeleteDoctor();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Wrong choice.");
                        break;
                }
            }
        }
        
        private static void ManagePatients()
        {
            Console.Write("1. Add patient | 2. List | 3. Update patient | 4. Delete patient | 0. Back: ");
            
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        _patientManager.AddPatient();
                        break;
                    case 2:
                        _patientManager.ListPatients();
                        break;
                    case 3:
                        _patientManager.UpdatePatient();
                        break;
                    case 4:
                        _patientManager.DeletePatient();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Wrong choice.");
                        break;
                }
            }
        }
        
        private static void ManageAppointments()
        {
            Console.WriteLine("1. Add appointment | 2. List appointment | 3. Update appointment | 4. Delete appointment | 0. Back: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        _appointmentManager.AddAppointment();
                        break;
                    case 2:
                        _appointmentManager.ListAppointment();
                        break;
                    case 3:
                        _appointmentManager.UpdateAppointment();
                        break;
                    case 4:
                        _appointmentManager.DeleteAppointment();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("wrong choice.");
                        break;
                }
            }
        }
        private enum Menu
        {
            ManageDoctors = 1,
            ManagePatients = 2,
            ManageAppointments = 3,
            Exit = 0,
        }
    }
}