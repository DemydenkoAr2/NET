using System.Collections;

// Класс Задачи, реализующий ICloneable и IComparable
class TodoItem : ICloneable, IComparable<TodoItem>
{
	public string Name { get; set; }
	public int Priority { get; set; } // Чем меньше число, тем выше приоритет
	public DateTime DueDate { get; set; }

	public TodoItem(string name, int priority, DateTime dueDate)
	{
		Name = name;
		Priority = priority;
		DueDate = dueDate;
	}

	// Реализация ICloneable
	public object Clone()
	{
		return new TodoItem(Name, Priority, DueDate);
	}

	// Реализация IComparable (сортировка по приоритету и сроку)
	public int CompareTo(TodoItem other)
	{
		int priorityComparison = Priority.CompareTo(other.Priority);
		return priorityComparison != 0 ? priorityComparison : DueDate.CompareTo(other.DueDate);
	}

	public override string ToString()
	{
		return $"{Name} (Приоритет: {Priority}, Дата: {DueDate:dd.MM.yyyy})";
	}
}

// Кастомный итератор для списка задач
class TaskCollection : IEnumerable<TodoItem>
{
	private List<TodoItem> tasks = new List<TodoItem>();

	public void Add(TodoItem task) => tasks.Add(task);
	public void Sort() => tasks.Sort();

	public IEnumerator<TodoItem> GetEnumerator()
	{
		foreach (var task in tasks)
			yield return task;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Генератор случайных задач
class TaskGenerator
{
	private static Random random = new Random();

	public static IEnumerable<TodoItem> GenerateTasks(int count)
	{
		string[] names = { "Доклад", "Презентация", "Отчет", "Разработка", "Тестирование" };
		for (int i = 0; i < count; i++)
		{
			yield return new TodoItem(
				names[random.Next(names.Length)],
				random.Next(1, 6), // Приоритет от 1 до 5
				DateTime.Now.AddDays(random.Next(1, 30))
			);
		}
	}
}

public static class SimpleTodo
{
	public static void Start()
	{
		// v1
		//TaskCollection tasks = new TaskCollection();

		//// Генерируем и добавляем 5 задач
		//foreach (var task in TaskGenerator.GenerateTasks(5))
		//{
		//	tasks.Add(task);
		//}

		// v2
		TaskCollection tasks =
		[
				// Генерируем и добавляем 5 задач
				.. TaskGenerator.GenerateTasks(5),
		];

			Console.WriteLine("Сгенерированные задачи:");
		foreach (var task in tasks)
		{
			Console.WriteLine(task);
		}

		// Сортируем задачи
		tasks.Sort();
		Console.WriteLine("\nОтсортированные задачи:");
		foreach (var task in tasks)
		{
			Console.WriteLine(task);
		}

		// Клонирование задачи
		TodoItem clonedTask = (TodoItem)tasks.First().Clone();
		clonedTask.Name = "Копия - " + clonedTask.Name;
		Console.WriteLine("\nКлонированная задача:");
		Console.WriteLine(clonedTask);
	}
}
