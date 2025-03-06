namespace Lesson1.OOP
{
	class Person
	{
		public string name;
		public int age;
		public Company company;

		public Person()
		{
			name = "Undefined";
			age = 18;
			company = new Company();
		}

		public void Print()
		{
			Console.WriteLine($"Name: {name}  Age: {age} Company: {company.title}");
		}
	}

	class Company
	{
		public string title = "Unknown";
	}

	// Ланцюжок виклику конструкторів
	public class PersonV2
	{
		public string name;
		public int age;

		public PersonV2() : this("Неизвестно")    // 1 конструктор
		{
			Console.WriteLine("1 конструктор");
		}
		public PersonV2(string name) : this(name, 18) // 2 конструктор
		{
			Console.WriteLine("2 конструктор");
		}
		public PersonV2(string name, int age)     // 3 конструктор
		{
			this.name = name;
			this.age = age;
			Console.WriteLine("3 конструктор");
		}
		public void Print() => Console.WriteLine($"Name: {name}  Age: {age}");

		// Деконструктори

		/*
		Деконструктори (не плутати з деструкторами) дозволяють виконати декомпозицію об'єкта окремі частини.
		*/
		public void Deconstruct(out string personName, out int personAge, ref int number, in int num)
		{
			Console.WriteLine(number);
			personName = name;
			personAge = age;

			Console.WriteLine(personName);
			//number = 1111;
			Console.WriteLine(num);
			// num = 11;
		}

		public void SwapNumber(ref int number1, ref int number2)
		{
			var temp = number1;
			number1 = number2;
			number2 = temp;
		}
	}

	public class Demo
	{
		public const int number1 = 10;
		public readonly int number2 = 20;

		public Demo()
		{
			// number1 = 10;
			number2 = 20;
		}

		public void Print()
		{
		}
	}

	public static class FirstExample
	{
		public static void Test()
		{
			var person = new Person();
			person.Print();

			var person2 = new PersonV2();
			int number1 = 10;
			int number2 = 20;
			person2.Deconstruct(out string name, out int age, ref number1, number2);
		}
	}
}
