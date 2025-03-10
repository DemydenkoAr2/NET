namespace Task_1_Employee;

class Program
{
    static void Main(string[] args)
    {
        Employee employeeArtem = new Employee("Artem", "QA", 1200m);
        Employee employeeAlex = new Employee("Alex", "QA Automation", 1600m);

        employeeArtem += 400;
        employeeAlex -= 200;

        employeeArtem.GetInfo(); // Name: Artem, Position: QA, Salary: 1600
        employeeAlex.GetInfo(); // Name: Alex, Position: QA Automation, Salary: 1400

        Console.WriteLine(employeeArtem > employeeAlex); // True 
        Console.WriteLine(employeeArtem < employeeAlex); // False
        Console.WriteLine(employeeArtem == employeeAlex); // False
        Console.WriteLine(employeeArtem != employeeAlex); // True
    }
}