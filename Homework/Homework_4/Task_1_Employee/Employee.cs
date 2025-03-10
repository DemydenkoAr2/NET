namespace Task_1_Employee;

public class Employee
{
    private string Name { get; set; }
    private string Position { get; set; }
    private decimal Salary { get; set; }

    public Employee(string name, string position, decimal salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public static Employee operator +(Employee employee, decimal amount)
    {
        employee.Salary += amount;
        return employee;
    }

    public static Employee operator -(Employee employee, decimal amount)
    {
        employee.Salary -= amount;
        return employee;
    }

    public static bool operator >(Employee employee1, Employee employee2)
    {
        return employee1.Salary > employee2.Salary;
    }

    public static bool operator <(Employee employee1, Employee employee2)
    {
        return employee1.Salary < employee2.Salary;
    }

    public static bool operator ==(Employee employee1, Employee employee2)
    {
        return employee1.Salary == employee2.Salary;
    }
 
    public static bool operator !=(Employee employee1, Employee employee2)
    {
        return employee1.Salary != employee2.Salary;
    }
 
    public void GetInfo()
    {
        Console.WriteLine($"Name: {Name}, Position: {Position}, Salary: {Salary}");
    }
}