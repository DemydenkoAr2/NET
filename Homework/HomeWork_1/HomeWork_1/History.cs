namespace HomeWork_1;

public class History
{
    private List<string> _history = new List<string>();
    
    public void Add(string entry) => _history.Add(entry);
    
    public void Display()
    {
        if (_history.Count > 0)
        {
            for (int i = 0; i < _history.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_history[i]}");
            }
        }
        else
        {
            Console.WriteLine("No history");
        }
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            _history.RemoveAt(_history.Count - 1);
        }
    }

    public void Clear() => _history.Clear();
}