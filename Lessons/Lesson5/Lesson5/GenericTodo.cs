// Generic interface for a task
public interface ITask<T> where T : IComparable<T>
{
	Guid Id { get; }
	string Description { get; }
	T Priority { get; }
	bool IsCompleted { get; }
	void Complete();
}

// Generic class for a task
public class TaskItem<T> : ITask<T> where T : IComparable<T>
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Description { get; }
	public T Priority { get; }
	public bool IsCompleted { get; private set; }

	public TaskItem(string description, T priority)
	{
		Description = description;
		Priority = priority;
		IsCompleted = false;
	}

	public void Complete()
	{
		IsCompleted = true;
	}

	public override string ToString()
	{
		return $"[{(IsCompleted ? "✔" : "✖")}] {Description} (Priority: {Priority})";
	}
}

// Generic class for task management
public class TaskManager<T> where T : IComparable<T>
{
	private readonly List<TaskItem<T>> _tasks = new List<TaskItem<T>>();

	public TaskItem<T> AddTask(string description, T priority)
	{
		var task = new TaskItem<T>(description, priority);
		_tasks.Add(task);
		return task;
	}

	public void CompleteTask(Guid taskId)
	{
		var task = _tasks.FirstOrDefault(t => t.Id == taskId);
		if (task != null)
		{
			task.Complete();
		}
	}

	public void RemoveTask(Guid taskId)
	{
		_tasks.RemoveAll(t => t.Id == taskId);
	}

	public void PrintTasks()
	{
		var sortedTasks = _tasks.OrderBy(t => t.Priority).ThenBy(t => t.IsCompleted).ToList();
		foreach (var task in sortedTasks)
		{
			Console.WriteLine(task);
		}
	}
}

// Main program class
class GenericTodo
{
	public static void Test()
	{
		TaskManager<int> taskManager = new TaskManager<int>();

		taskManager.AddTask("Buy milk", 2);
		taskManager.AddTask("Do homework", 1);
		taskManager.AddTask("Call a friend", 3);

		Console.WriteLine("Task list:");
		taskManager.PrintTasks();

		Console.WriteLine("\nCompleting a task...");
		var taskToComplete = taskManager.AddTask("Fix the computer", 1);
		taskManager.CompleteTask(taskToComplete.Id);

		Console.WriteLine("\nUpdated task list:");
		taskManager.PrintTasks();
	}
}
