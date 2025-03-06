namespace HomeWork_1;

public class Calculator
{
    protected History _history;

    protected Calculator(History history)
    {
        _history = history;
    }
    
    private void AddHistory(string entry)
    {
        _history.Add(entry);
    }

    protected void LogOperation(string entry)
    {
        AddHistory(entry);
        Console.WriteLine(entry);
    }

    protected void LogDivisionByZero()
    {
        AddHistory("Division By Zero");
        Console.WriteLine("Division by Zero");
    }
}