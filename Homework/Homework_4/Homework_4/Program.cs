namespace Homework_4;

class Program
{
    static void Main(string[] args)
    {
        Employee employeeArtem = new Employee("Artem", "QA", 1200m);
        Employee employeeAlex = new Employee("Alex", "QA Automation", 1600m);

        employeeArtem += 400;
        employeeAlex -= 200;

        employeeArtem.GetInfo();
        employeeAlex.GetInfo();

        Console.WriteLine(employeeArtem > employeeAlex);
        Console.WriteLine(employeeArtem < employeeAlex);
        Console.WriteLine(employeeArtem == employeeAlex);
        Console.WriteLine(employeeArtem != employeeAlex);
    }
}