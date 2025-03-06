// Интерфейс для транспорта
interface IDeliverable
{
	void LoadOrder(Order order);   // Загрузка заказа
	void Deliver();                // Доставка заказа
	void Unload();                 // Выгрузка заказа
}

// Класс заказа
class Order(string description, double weight)
{
	public string Description { get; } = description;
	public double Weight { get; } = weight;

	public override string ToString() => $"Заказ: {Description}, Вес: {Weight} кг";
}

// Абстрактный класс транспорта
abstract class Transport(string model, double maxLoad) : IDeliverable
{
	public string Model { get; } = model;
	public double MaxLoad { get; } = maxLoad;
	protected List<Order> LoadedOrders = [];

	public abstract void LoadOrder(Order order);
	public abstract void Deliver();
	public abstract void Unload();

	protected double CurrentLoad() => LoadedOrders.Sum(o => o.Weight);
}

// Класс автомобиля
class Car(string model) : Transport(model, 100)
{
	public override void LoadOrder(Order order)
	{
		if (CurrentLoad() + order.Weight <= MaxLoad)
		{
			LoadedOrders.Add(order);
			Console.WriteLine($"Автомобиль {Model} загрузил: {order}");
		}
		else
		{
			Console.WriteLine($"Автомобиль {Model} не может взять {order.Description}: перегруз!");
		}
	}

	public override void Deliver()
	{
		if (LoadedOrders.Count > 0)
		{
			Console.WriteLine($"Автомобиль {Model} везет {LoadedOrders.Count} заказ(ов) к клиенту!");
		}
		else
		{
			Console.WriteLine($"Автомобиль {Model} пуст и не может доставлять!");
		}
	}

	public override void Unload()
	{
		Console.WriteLine($"Автомобиль {Model} доставил {LoadedOrders.Count} заказ(ов).");
		LoadedOrders.Clear();
	}
}

// Класс велосипеда
class Bicycle(string model) : Transport(model, 10)
{
	public override void LoadOrder(Order order)
	{
		if (CurrentLoad() + order.Weight <= MaxLoad)
		{
			LoadedOrders.Add(order);
			Console.WriteLine($"Велосипед {Model} загрузил: {order}");
		}
		else
		{
			Console.WriteLine($"Велосипед {Model} не может взять {order.Description}: слишком тяжелый!");
		}
	}

	public override void Deliver()
	{
		Console.WriteLine($"Велосипед {Model} доставляет заказ!");
	}

	public override void Unload()
	{
		Console.WriteLine($"Велосипед {Model} доставил заказ.");
		LoadedOrders.Clear();
	}
}

// Класс дрона
class Drone(string model) : Transport(model, 5)
{
	public override void LoadOrder(Order order)
	{
		if (CurrentLoad() + order.Weight <= MaxLoad)
		{
			LoadedOrders.Add(order);
			Console.WriteLine($"Дрон {Model} загрузил: {order}");
		}
		else
		{
			Console.WriteLine($"Дрон {Model} не может взять {order.Description}: слишком тяжелый!");
		}
	}

	public override void Deliver()
	{
		Console.WriteLine($"Дрон {Model} летит к клиенту!");
	}

	public override void Unload()
	{
		Console.WriteLine($"Дрон {Model} доставил заказ.");
		LoadedOrders.Clear();
	}
}

public static class SimpleDeliverySystem
{
	public static void Start()
	{
		List<Transport> vehicles =
		[
			new Car("Toyota"),
			new Bicycle("BMX"),
			new Drone("DJI Phantom")
		];

		List<Order> orders =
		[
			new Order("Ноутбук", 3),
			new Order("Мебель", 50),
			new Order("Книга", 1),
			new Order("Холодильник", 120),
			new Order("Кофемашина", 7)
		];

		Console.WriteLine("=== Раздача заказов транспорту ===");
		foreach (var order in orders)
		{
			foreach (var vehicle in vehicles)
			{
				vehicle.LoadOrder(order);
			}
		}

		Console.WriteLine("\n=== Доставка заказов ===");
		foreach (var vehicle in vehicles)
		{
			vehicle.Deliver();
		}

		Console.WriteLine("\n=== Завершение доставки ===");
		foreach (var vehicle in vehicles)
		{
			vehicle.Unload();
		}
	}
}
