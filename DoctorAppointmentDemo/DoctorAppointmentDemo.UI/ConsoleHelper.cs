using System.Globalization;

namespace DoctorAppointmentDemo.UI;

public static class ConsoleHelper
{
    public static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    public static DateTime ReadDateTime(string prompt, string format = "dd/MM/yyyy HH:mm")
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            Console.WriteLine($"Invalid date format. Please use the format: {format}");
        }
    }

    public static T ReadEnum<T>(string prompt) where T : struct, Enum
    {
        Console.WriteLine(prompt);
        foreach (var value in Enum.GetValues(typeof(T)))
        {
            Console.WriteLine($"{(int)value}. {value}");
        }

        while (true)
        {
            Console.Write("Enter number: ");
            if (Enum.TryParse(Console.ReadLine(), out T result) && Enum.IsDefined(typeof(T), result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid number from the list.");
        }
    }
}